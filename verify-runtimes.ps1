param([Parameter(Mandatory = $true)][string]$RuntimeRoot)
$ErrorActionPreference = 'Stop'
foreach ($pair in @(@('2.1','netcoreapp2.1'),@('2.2','netcoreapp2.2'),@('3.0','netcoreapp3.0'),@('3.1','netcoreapp3.1'),@('5.0','net5.0'),@('7.0','net7.0'))) {
    $hostPath = Join-Path $RuntimeRoot "$($pair[0])/dotnet.exe"
    if (!(Test-Path -LiteralPath $hostPath)) { throw "Missing isolated runtime: $hostPath" }
    & $hostPath (Join-Path $PSScriptRoot "Compatibility.Smoke/bin/Release/$($pair[1])/Compatibility.Smoke.dll")
    if ($LASTEXITCODE -ne 0) { throw "Runtime smoke failed: $($pair[1])" }
    Write-Output "Verified: $($pair[1])"
}
foreach ($framework in @('net6.0','net8.0','net9.0','net10.0')) {
    dotnet (Join-Path $PSScriptRoot "Compatibility.Smoke/bin/Release/$framework/Compatibility.Smoke.dll")
    if ($LASTEXITCODE -ne 0) { throw "Runtime smoke failed: $framework" }
    Write-Output "Verified: $framework"
}