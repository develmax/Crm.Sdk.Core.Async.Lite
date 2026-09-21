# Crm.Sdk.Core.Async.Lite

![Logo of the project](https://raw.githubusercontent.com/develmax/Crm.Sdk.Core.Async.Lite/main/Crm.Sdk.Core.Async.Lite.Package/icon.png)

Async SDK for Microsoft Dynamics CRM on-premises, including CRM 2015.

[![NuGet](https://img.shields.io/nuget/v/DevelKit.Crm.Sdk.Lite.svg)](https://www.nuget.org/packages/DevelKit.Crm.Sdk.Lite/)

## Install

```shell
dotnet add package DevelKit.Crm.Sdk.Lite --version 11.0.0
```

The 11.0.0 release is prepared in this repository; the package owner publishes it
to NuGet separately. Until then, use the generated nupkg from a local feed.
ADFS, Live ID and Dynamics 365 Online authentication are not implemented.

## Full SDK alternative

[Crm.Sdk.Core.Async](https://github.com/develmax/Crm.Sdk.Core.Async)
(package `Crm.Sdk.Core`) includes the WCF SDK and a similar direct SOAP-over-HTTP
implementation through `Microsoft.Xrm.Sdk.OData.OrganizationDataWebServiceProxy`.
If you already use Full, this client is available in its `Microsoft.Xrm.Sdk.OData`
assembly, with separate types in that namespace.

This Lite package (`DevelKit.Crm.Sdk.Lite`) provides direct SOAP-over-HTTP with
familiar SDK namespaces and class names, including `Microsoft.Xrm.Sdk.Entity`
and `Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy`, without WCF dependencies
or WCF channel infrastructure. Lite does not guarantee faster CRM requests.

The `Microsoft.Xrm.Sdk.OData` assembly may be removed from Full in a future release,
with the direct HTTP implementation maintained only in Lite. This is a possible
direction, not an announced removal; no removal version or date has been set.

Use one package variant per application: their assembly names overlap.

## Framework compatibility

| Consumer | Selected package assets |
| --- | --- |
| .NET Core 2.1, 2.2, 3.0, 3.1 and .NET 5 | netstandard2.0 |
| .NET 6, 7, 8, 9, 10 | matching net6.0 through net10.0 |

Build with the .NET 10 SDK. Older target compatibility does not imply that those
runtimes still receive security updates from Microsoft. Regression suites target
.NET 6, 8, 9 and 10. Package smoke tests (serialization, two pooled SOAP calls,
and cancellation isolation) also passed on Windows with runtimes 2.1.30, 2.2.8,
3.0.3, 3.1.32, 5.0.17 and 7.0.20. This is local protocol validation, not a live
CRM compatibility certification.

## NTLM and connection lifetime

NTLM/Negotiate authentication is performed by HttpClientHandler so the transport
keeps the handshake on one connection and reuses authenticated sockets. The old
manual handshake and its hidden HttpClient timeout have been removed. Credentials
are restricted to NTLM/Negotiate on the first CRM authority; redirects are not
followed. Configure credentials and proxy settings before the first call.

Windows uses SSPI. Linux needs a working GSSAPI NTLM provider (for example the
OS package gss-ntlmssp); validate the target container with your domain. A managed
NTLM fallback is no longer provided. Never disable TLS validation to make a
connection work; install the organization's trusted CA certificates instead.

Keep each proxy alive for its owner's lifetime and dispose it when that owner
stops. Lite/OData keep a handler per proxy; per-call HttpClient wrappers do not
destroy its connection pool. Do not use a WCF proxy concurrently: lease it to one
operation at a time. Do not mutate a NetworkCredential while it is in use.

## Cancellation, timeouts and writes

Cancellation is local. CRM 2015 does not accept a .NET CancellationToken as part
of its SOAP contract. Canceling or timing out a client does **not** confirm that
CRM rolled back a write. After dispatch, a lost response means the outcome can
be unknown; reconcile the result before repeating a create.

The Full proxy Timeout maps to WCF binding timeouts and channel OperationTimeout.
Lite/OData use the per-call HttpClient timeout. Registration of local cancellation
is scoped to one call and cannot abort a later pooled call. Write operations and
generic Execute are not automatically replayed by the Full proxy after errors.

CRM's standard duplicate detection can be requested with CreateRequest and
SuppressDuplicateDetection=false. It requires enabled, published server rules
and is not an atomic uniqueness guarantee for concurrent creates.

## Version 11 migration

The Lite package is prepared as `DevelKit.Crm.Sdk.Lite`. Previous repository
packaging incorrectly used the Full package ID. Lite uses direct SOAP/HTTP and
includes `Microsoft.Xrm.Sdk` and `Microsoft.Crm.Sdk`. Do not install both variants
in one application: their assembly names overlap.

## Build and verify

```powershell
./build.ps1
```

Install .NET runtimes 6, 8, 9 and 10 to execute the test matrix. The script builds
all target assets, runs the isolated loopback tests, compiles package consumers
for .NET Core 2.1, 2.2, 3.0, 3.1 and .NET 5-10, and puts the nupkg in
artifacts/. Use -SkipTests only if test execution is handled separately.
To repeat runtime smoke tests with isolated Windows runtimes, run
`./verify-runtimes.ps1 -RuntimeRoot <directory>`; the directory contains
2.1/, 2.2/, 3.0/, 3.1/, 5.0/ and 7.0/ dotnet installations.

Tests never connect to a live CRM. The NTLM handshake test uses a native server
challenge on .NET 8+ and checks connection affinity and request count; it is not
a domain-credential validation test.

## Support development

If this library helps you, you can support its maintenance, tests, and documentation.
Donations are optional; the library remains freely available under the MIT license.

[Open Collective](https://opencollective.com/crmsdkcore) · [Patreon](https://www.patreon.com/develmax) · [Boosty](https://boosty.to/develmax/donate) · [YooMoney](https://yoomoney.ru/to/4100119529133322) · [PayPal](https://paypal.me/develmax)

## License

MIT. See [LICENSE.md](LICENSE.md).