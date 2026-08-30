# Soenneker.Normalizers.Phone
[![](https://img.shields.io/nuget/v/soenneker.normalizers.phone.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.phone/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.phone/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.phone/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.normalizers.phone.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.normalizers.phone/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.normalizers.phone/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.normalizers.phone/actions/workflows/codeql.yml)

Normalizes common North American and international dialing forms to a `+` followed by ASCII digits.

## Installation

```bash
dotnet add package Soenneker.Normalizers.Phone
```

## Registration

```csharp
using Soenneker.Normalizers.Phone.Registrars;

builder.Services.AddPhoneNormalizerAsSingleton();
// or: builder.Services.AddPhoneNormalizerAsScoped();
```

The implementation has no mutable per-call state and can be shared as a singleton.

## Usage

```csharp
using Soenneker.Normalizers.Phone.Abstract;

string? normalized = normalizer.Normalize("(412) 555-0100");
// "+14125550100"
```

Supported forms include:

| Input | Result |
| --- | --- |
| `(412) 555-0100` | `+14125550100` |
| `1-412-555-0100` | `+14125550100` |
| ` +44 20 7946 0958` | `+442079460958` |
| `011 44 20 7946 0958` | `+442079460958` |
| `00 44 20 7946 0958` | `+442079460958` |

Ten digits are assumed to be a North American number and receive country code `1`. Eleven digits beginning with `1` are treated as already including that country code. Other international numbers require a leading `+`, `011`, or `00`, must retain 11 to 15 digits after the dialing prefix, and cannot begin with zero.

Non-numeric characters are ignored and only ASCII digits count. Extensions are not parsed; extension digits become part of the digit count and commonly cause a `null` result. A long international digit string without an explicit international prefix also returns `null`.

This is canonicalization, not full E.164 or numbering-plan validation. It does not validate country codes, North American area/exchange rules, subscriber-number lengths for a country, ownership, or reachability. Use a numbering-plan-aware library or verification flow when those guarantees matter.

Phone numbers are personal data. Avoid logging raw or normalized values and apply appropriate storage, access, and retention controls.
