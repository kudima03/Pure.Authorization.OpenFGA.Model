# Pure.Authorization.OpenFGA.Model

Concrete implementations of the OpenFGA authorization model for the **Pure** ecosystem: immutable, AOT-compatible records implementing the `Pure.Authorization.OpenFGA.Model.Abstractions` contracts, plus OpenFGA text forms of subjects, objects and tuples.

[![.NET build & test](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Authorization.OpenFGA.Model)](https://www.nuget.org/packages/Pure.Authorization.OpenFGA.Model)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Authorization.OpenFGA.Model` provides sealed record implementations of every interface defined in [`Pure.Authorization.OpenFGA.Model.Abstractions`](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model.Abstractions). Each type is immutable by construction, taking all values through its constructor, and uses [`IString`](https://github.com/kudima03/Pure.Primitives.Abstractions) from `Pure.Primitives.Abstractions` for all string-valued properties.

On top of the records, the package ships text forms that render model values into the canonical strings OpenFGA uses.

Records do no validation. Checking a tuple or a relation against an authorization model belongs to `Pure.Authorization.OpenFGA.Model.Conditions`, and parsing text back into records belongs to `Pure.Authorization.OpenFGA.Model.Abstractions.Serialization.System`.

## Types

### Records

One sealed record per interface. Each namespace mirrors the matching folder of the abstractions.

| Namespace | Type | Implements | Description |
|-----------|------|------------|-------------|
| `Pure.Authorization.OpenFGA.Model.Model` | `AuthorizationModel` | `IAuthorizationModel` | Schema version, type definitions and conditions |
| | `TypeDefinition` | `ITypeDefinition` | An object type and its relations (`type document`) |
| | `RelationDefinition` | `IRelationDefinition` | A named relation and its rewrite (`define viewer: ...`) |
| `Pure.Authorization.OpenFGA.Model.Rewrite` | `Direct` | `IDirect` | Directly assignable subject forms (`[user, group#member]`) |
| | `ComputedRelation` | `IComputedRelation` | Another relation on the same object (`editor`) |
| | `RelationFrom` | `IRelationFrom` | A relation on related objects (`viewer from parent`) |
| | `Union` | `IUnion` | Any of the children (`a or b`) |
| | `Intersection` | `IIntersection` | All of the children (`a and b`) |
| | `Difference` | `IDifference` | Base minus subtracted part (`a but not b`) |
| `Pure.Authorization.OpenFGA.Model.SubjectForm` | `TypeForm` | `ITypeForm` | Any object of a type (`user`) |
| | `SubjectSetForm` | `ISubjectSetForm` | Holders of a relation on a type (`group#member`) |
| | `WildcardForm` | `IWildcardForm` | Public-access wildcard (`user:*`) |
| | `ConditionalForm` | `IConditionalForm` | A form written with a condition (`user with non_expired`) |
| `Pure.Authorization.OpenFGA.Model.Condition` | `Condition` | `ICondition` | A named CEL expression over typed parameters |
| | `ConditionParameter` | `IConditionParameter` | A typed parameter (`grant_time: timestamp`) |
| | `ConditionParameterType` | `IConditionParameterType` | A parameter type with generic arguments (`list<string>`) |
| `Pure.Authorization.OpenFGA.Model.Object` | `Object` | `IObject` | An object of a type (`document:1`); also a subject |
| `Pure.Authorization.OpenFGA.Model.Subject` | `SubjectSet` | `ISubjectSet` | Holders of a relation on an object (`group:eng#member`) |
| | `TypedWildcard` | `ITypedWildcard` | Every object of a type (`user:*`) |
| `Pure.Authorization.OpenFGA.Model.Tuple` | `Tuple` | `ITuple` | Subject, relation and object of a relationship tuple |
| | `ConditionalTuple` | `IConditionalTuple` | Decorates an `ITuple` with a condition; subject, relation and object come from the wrapped tuple |
| | `RelationshipCondition` | `IRelationshipCondition` | A condition name and its JSON context |

Constructors whose last parameter is a collection take it as `params IEnumerable<T>`, so `new Union(a, b, c)`, `new Direct(new TypeForm(user))` and `new TypeDefinition(document, viewer, editor)` read naturally. A collection can still be passed as is.

`Object`, `Condition` and `Tuple` share their name with the last segment of their namespace, as `Table` and `Index` do in `Pure.RelationalSchema`. Outside their own namespace, refer to them through a using alias, e.g. `using Object = Pure.Authorization.OpenFGA.Model.Object.Object;`.

### Text forms

Each text form implements `IString` and composes the string lazily from `Pure.Primitives` building blocks, so it reflects the record it wraps at the time it is read.

| Type | Namespace | Renders |
|------|-----------|---------|
| `ObjectString` | `Pure.Authorization.OpenFGA.Model.Object` | An `IObject` |
| `SubjectString` | `Pure.Authorization.OpenFGA.Model.Subject` | An `ISubject` |
| `SubjectFormString` | `Pure.Authorization.OpenFGA.Model.SubjectForm` | An `ISubjectForm`, in DSL syntax |
| `TupleString` | `Pure.Authorization.OpenFGA.Model.Tuple` | An `ITuple` |

| Input | Shape | Example |
|-------|-------|---------|
| `IObject` (object or direct subject) | `type:id` | `document:roadmap`, `user:anne` |
| `ISubjectSet` | `type:id#relation` | `group:eng#member` |
| `ITypedWildcard` | `type:*` | `user:*` |
| `ITypeForm` | `type` | `user` |
| `ISubjectSetForm` | `type#relation` | `group#member` |
| `IWildcardForm` | `type:*` | `user:*` |
| `IConditionalForm` | `<form> with <condition>` | `user with non_expired`, `group#member with in_region` |
| `ITuple` | `object#relation@subject` | `document:1#viewer@group:eng#member` |

Notes:

- `SubjectString` and `SubjectFormString` dispatch over the closed variant sets. An implementation of `ISubject` or `ISubjectForm` that is none of the known variants makes reading the text throw `ArgumentException`.
- The condition of an `IConditionalTuple` is not part of `TupleString`: a conditional tuple is written exactly like the tuple it wraps.
- Parts are written as they are, with no validation or escaping.
- The text forms only write strings. Parsing is not part of this package.

## Design Principles

- **Immutable**: all properties are get-only; values are set once in the constructor and never changed.
- **Composable**: records depend only on abstractions, so any implementation can be substituted.
- **No implicit text or hashing**: `GetHashCode()` and `ToString()` throw `NotSupportedException`, as in the rest of the Pure ecosystem. Use the text forms to get OpenFGA strings.
- **AOT-compatible**: sealed records with no reflection-based code paths; the package is fully compatible with Native AOT.

## Dependencies

- [`Pure.Authorization.OpenFGA.Model.Abstractions`](https://github.com/kudima03/Pure.Authorization.OpenFGA.Model.Abstractions/tree/0.1.0-preview.0.1.0) `0.1.0-preview.0.1.0`: the interfaces this package implements
- [`Pure.Primitives`](https://github.com/kudima03/Pure.Primitives/tree/3.7.0) `3.7.0`: the separator strings (`ColonString`, `HashString`, `AtString`, `AsteriskString`) and `String` used by the text forms
- [`Pure.Primitives.String.Operations`](https://github.com/kudima03/Pure.Primitives.String.Operations/tree/1.7.0) `1.7.0`: `ConcatenatedString`, `ColonJoinedString` and `WhitespaceJoinedString`, which compose the text forms
- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions): base primitive interfaces, through the packages above; `IString` is used for all string-valued properties

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

```csharp
using System.Text.Json.Nodes;
using Pure.Authorization.OpenFGA.Model.Abstractions.Model;
using Pure.Authorization.OpenFGA.Model.Abstractions.Tuple;
using Pure.Authorization.OpenFGA.Model.Model;
using Pure.Authorization.OpenFGA.Model.Rewrite;
using Pure.Authorization.OpenFGA.Model.Subject;
using Pure.Authorization.OpenFGA.Model.SubjectForm;
using Pure.Authorization.OpenFGA.Model.Tuple;
using Pure.Primitives.Abstractions.String;
using Condition = Pure.Authorization.OpenFGA.Model.Condition.Condition;
using ConditionParameter = Pure.Authorization.OpenFGA.Model.Condition.ConditionParameter;
using ConditionParameterType = Pure.Authorization.OpenFGA.Model.Condition.ConditionParameterType;
using Object = Pure.Authorization.OpenFGA.Model.Object.Object;
using String = Pure.Primitives.String.String;
using Tuple = Pure.Authorization.OpenFGA.Model.Tuple.Tuple;

// model
//   schema 1.1
//   type user
//   type group
//     relations
//       define member: [user]
//   type document
//     relations
//       define editor: [user]
//       define viewer: [user, user:*, group#member, user with non_expired] or editor
//   condition non_expired(grant_time: timestamp, duration: duration) {
//     request.current_time < grant_time + duration
//   }
IAuthorizationModel model = new AuthorizationModel(
    new String("1.1"),
    [
        new TypeDefinition(new String("user")),
        new TypeDefinition(
            new String("group"),
            new RelationDefinition(
                new String("member"),
                new Direct(new TypeForm(new String("user")))
            )
        ),
        new TypeDefinition(
            new String("document"),
            new RelationDefinition(
                new String("editor"),
                new Direct(new TypeForm(new String("user")))
            ),
            new RelationDefinition(
                new String("viewer"),
                new Union(
                    new Direct(
                        new TypeForm(new String("user")),
                        new WildcardForm(new String("user")),
                        new SubjectSetForm(new String("group"), new String("member")),
                        new ConditionalForm(
                            new TypeForm(new String("user")),
                            new String("non_expired")
                        )
                    ),
                    new ComputedRelation(new String("editor"))
                )
            )
        ),
    ],
    [
        new Condition(
            new String("non_expired"),
            new String("request.current_time < grant_time + duration"),
            new ConditionParameter(
                new String("grant_time"),
                new ConditionParameterType(new String("timestamp"))
            ),
            new ConditionParameter(
                new String("duration"),
                new ConditionParameterType(new String("duration"))
            )
        ),
    ]
);

ITuple tuple = new Tuple(
    new SubjectSet(new Object(new String("group"), new String("eng")), new String("member")),
    new String("viewer"),
    new Object(new String("document"), new String("roadmap"))
);

IString text = new TupleString(tuple);
// text.TextValue == "document:roadmap#viewer@group:eng#member"

ITuple temporary = new ConditionalTuple(
    new Tuple(
        new Object(new String("user"), new String("anne")),
        new String("viewer"),
        new Object(new String("document"), new String("roadmap"))
    ),
    new RelationshipCondition(
        new String("non_expired"),
        new JsonObject
        {
            ["grant_time"] = "2026-01-01T00:00:00Z",
            ["duration"] = "24h",
        }
    )
);
// new TupleString(temporary).TextValue == "document:roadmap#viewer@user:anne"

IString form = new SubjectFormString(
    new ConditionalForm(new TypeForm(new String("user")), new String("non_expired"))
);
// form.TextValue == "user with non_expired"
```
