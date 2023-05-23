# Crm.Sdk.Core.Async.Lite

![Logo of the project](https://github.com/develmax/Crm.Sdk.Core.Async.Lite/blob/master/Crm.Sdk.Core.Async.Lite.Package/icon.png)

[![CodeFactor](https://www.codefactor.io/repository/github/develmax/crm.sdk.core.async.lite/badge)](https://www.codefactor.io/repository/github/develmax/crm.sdk.core.async.lite)
[![Travis build status](https://api.travis-ci.com/develmax/Crm.Sdk.Core.Async.Lite.svg?branch=master)](https://travis-ci.com/github/develmax/Crm.Sdk.Core.Async.Lite?branch=master)
[![NuGet Status](https://img.shields.io/nuget/v/Crm.Sdk.Core.Lite.svg?style=flat)](https://www.nuget.org/packages/Crm.Sdk.Core.Lite/) (6.X versions)

This project was created to port the official libraries Microsoft.Xrm.Sdk and Microsoft.Crm.Sdk to work with Microsoft Dynamics CRM 2015 (and etc.) via API from .NET Core 6.0 platform. This package does not include authentication via adfs, liveid, dynamics crm365.

## Installing / Getting started

Crm.Sdk.Core.Async.Lite is available from NuGet

```shell
dotnet package install Crm.Sdk.Core --version 6.1.5
```

You can also use your favorite NuGet client.

## Developing

Here's a brief intro about what a developer must do in order to start developing
the project further:

```shell
git clone https://github.com/develmax/Crm.Sdk.Core.Async.Lite.git
cd Crm.Sdk.Core.Async.Lite
dotnet restore
```

Clone the repository and then restore the development requirements. You can use
any editor, Rider, VS Code or VS 2022. The library supports all .NET Core
platforms.

### Building

Building is simple

```shell
dotnet build
```

### Deploying / Publishing

```shell
git pull
versionize
dotnet pack
dotnet nuget push
git push
```

## Contributing

When you publish something open source, one of the greatest motivations is that
anyone can just jump in and start contributing to your project.

These paragraphs are meant to welcome those kind souls to feel that they are
needed. You should state something like:

"If you'd like to contribute, please fork the repository and use a feature
branch. Pull requests are warmly welcome."

If there's anything else the developer needs to know (e.g. the code style
guide), you should link it here. If there's a lot of things to take into
consideration, it is common to separate this section to its own file called
`CONTRIBUTING.md` (or similar). If so, you should say that it exists here.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
