param([switch]$SkipTests)
$ErrorActionPreference = 'Stop'
Push-Location $PSScriptRoot
try {
    foreach ($project in Get-ChildItem -Path 'Microsoft.*/*.csproj') {
        dotnet build $project.FullName -c Release --nologo -m:1 -nr:false -p:BuildInParallel=false -v quiet /clp:ErrorsOnly
        if ($LASTEXITCODE -ne 0) { throw "Build failed: $($project.Name)" }
    }
    if (!$SkipTests) {
        foreach ($framework in @('net6.0','net8.0','net9.0','net10.0')) {
            dotnet test 'Transport.Tests/Transport.Tests.csproj' -c Release -f $framework --nologo -m:1 -nr:false -p:BuildInParallel=false -v quiet /clp:ErrorsOnly
            if ($LASTEXITCODE -ne 0) { throw "Tests failed: $framework" }
        }
        if ($LASTEXITCODE -ne 0) { throw 'Transport tests failed.' }
    }
    $package = Get-ChildItem -Path '*.Package/*.csproj' | Select-Object -First 1
    dotnet pack $package.FullName -c Release -o artifacts --nologo -m:1 -nr:false -p:BuildInParallel=false -v minimal
    if ($LASTEXITCODE -ne 0) { throw 'Packaging failed.' }
    # Consumers must compile against the nupkg (not ProjectReference). Keep their
    # local SDK package cache fresh when iterating on an unpublished version.
    [xml]$metadata = Get-Content (Join-Path $package.DirectoryName ($package.BaseName + '.nuspec'))
    $id = $metadata.package.metadata.id.ToLowerInvariant()
    $version = $metadata.package.metadata.version
    $cacheRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot 'artifacts/consumer-cache'))
    $cacheVersion = [IO.Path]::GetFullPath((Join-Path $cacheRoot "$id/$version"))
    if (!$cacheVersion.StartsWith($cacheRoot + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase)) {
        throw 'Unexpected package cache path.'
    }
    if (Test-Path -LiteralPath $cacheVersion) {
        $cachedPackage = Join-Path $cacheVersion "$id.$version.nupkg"
        $builtPackage = Join-Path $PSScriptRoot "artifacts/$($metadata.package.metadata.id).$version.nupkg"
        if (!(Test-Path -LiteralPath $cachedPackage) -or
            (Get-FileHash $cachedPackage).Hash -ne (Get-FileHash $builtPackage).Hash) {
            Remove-Item -LiteralPath $cacheVersion -Recurse -Force
        }
    }
    dotnet build 'Compatibility.Smoke/Compatibility.Smoke.csproj' -c Release --nologo -m:1 -nr:false -p:BuildInParallel=false -v quiet /clp:ErrorsOnly
    if ($LASTEXITCODE -ne 0) { throw 'Package consumer compatibility failed.' }
}
finally { Pop-Location }