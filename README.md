# Pure.Authorization.OpenFGA.Model

Concrete implementations of the OpenFGA authorization model for the **Pure** ecosystem: immutable, AOT-compatible records implementing the `Pure.Authorization.OpenFGA.Model.Abstractions` contracts, plus OpenFGA text forms of subjects, objects and tuples.

[![.NET build & test](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Authorization.OpenFGA.Model)](https://www.nuget.org/packages/Pure.Authorization.OpenFGA.Model)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

> **Status: coming soon.** The repository is initialized, but no public API has been released yet. The types described below are planned and will be added once `Pure.Authorization.OpenFGA.Model.Abstractions` is published.

## Overview

`Pure.Authorization.OpenFGA.Model` will provide sealed record implementations of every interface defined in [`Pure.Authorization.OpenFGA.Model.Abstractions`](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model.Abstractions). Each type will be immutable by construction, taking all values through its constructor, and will use [`IString`](https://github.com/kudima03/Pure.Primitives.Abstractions) from `Pure.Primitives.Abstractions` for all string-valued properties.

On top of the records, the package will ship text forms that render model values into the canonical strings OpenFGA uses.

## Planned types

### Records

One sealed record for each interface in `Pure.Authorization.OpenFGA.Model.Abstractions`.

### Text forms

| Type | Renders |
|------|---------|
| `ObjectString` | An object |
| `SubjectString` | A subject |
| `SubjectFormString` | A subject form |
| `TupleString` | A relationship tuple |

Together they produce OpenFGA's canonical strings:

| Form | Shape | Example |
|------|-------|---------|
| Object or direct subject | `type:id` | `document:roadmap`, `user:anne` |
| Userset subject | `type:id#relation` | `group:eng#member` |
| Wildcard subject | `type:*` | `user:*` |
| Relationship tuple | `object#relation@subject` | `document:roadmap#viewer@user:anne` |

All types will reside in the `Pure.Authorization.OpenFGA.Model` namespace.

## Design Principles

- **Immutable**: all properties are init-only; values are set once in the constructor and never changed.
- **Composable**: records depend only on abstractions, so any implementation can be substituted.
- **AOT-compatible**: sealed records with no reflection or dynamic dispatch; the package is fully compatible with Native AOT.

## Dependencies

Planned:

- [`Pure.Authorization.OpenFGA.Model.Abstractions`](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model.Abstractions): the interfaces this package implements
- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions): base primitive interfaces; `IString` is used for all string-valued properties

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```shell
dotnet add package Pure.Authorization.OpenFGA.Model
```

The package has not been published yet; this command will work after the first release.

## Usage

Coming soon.
