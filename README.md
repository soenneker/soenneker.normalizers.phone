[![](https://img.shields.io/nuget/v/soenneker.normalizers.phone.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.phone/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.phone/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.phone/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.normalizers.phone.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.phone/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.phone/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.phone/actions/workflows/codeql.yml)

# Soenneker.Normalizers.Phone

A performant utility method for converting user-entered phone numbers into strict E.164 format, supporting US and international dialing conventions with minimal allocations.

## Install

```bash
dotnet add package Soenneker.Normalizers.Phone
```

## Quick start

```csharp
using Soenneker.Normalizers.Phone.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddPhoneNormalizerAsSingleton();
```

Adds `IPhoneNormalizer` as a singleton service.

## What you get

- `IPhoneNormalizer` — A performant utility method for converting user-entered phone numbers into strict E.164 format, supporting US and international dialing conventions with minimal allocations.
- `PhoneNormalizerRegistrar` — A performant utility method for converting user-entered phone numbers into strict E.164 format, supporting US and international dialing conventions with minimal allocations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `PhoneNormalizerRegistrar.AddPhoneNormalizerAsSingleton(services)` | Adds `IPhoneNormalizer` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `PhoneNormalizerRegistrar.AddPhoneNormalizerAsScoped(services)` | Adds `IPhoneNormalizer` as a scoped service. | The same service collection, so additional registrations can be chained. |
