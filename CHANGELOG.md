# Changelog

All notable changes to Pure.Authorization.OpenFGA.Model are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [Unreleased]

### Added

- **Model records** in `Pure.Authorization.OpenFGA.Model.Model`:
  `AuthorizationModel` (`IAuthorizationModel`), `TypeDefinition`
  (`ITypeDefinition`) and `RelationDefinition` (`IRelationDefinition`).
- **Rewrite records** in `Pure.Authorization.OpenFGA.Model.Rewrite`:
  `Direct`, `ComputedRelation`, `RelationFrom`, `Union`, `Intersection`
  and `Difference`.
- **Subject form records** in `Pure.Authorization.OpenFGA.Model.SubjectForm`:
  `TypeForm`, `SubjectSetForm`, `WildcardForm` and `ConditionalForm`.
- **Condition records** in `Pure.Authorization.OpenFGA.Model.Condition`:
  `Condition`, `ConditionParameter` and `ConditionParameterType`.
- **Object, subject and tuple records**: `Object`
  (`Pure.Authorization.OpenFGA.Model.Object`), `SubjectSet` and
  `TypedWildcard` (`Pure.Authorization.OpenFGA.Model.Subject`), and
  `Tuple`, `ConditionalTuple` and `RelationshipCondition`
  (`Pure.Authorization.OpenFGA.Model.Tuple`). `ConditionalTuple` decorates
  an `ITuple`: subject, relation and object come from the wrapped tuple.
- Trailing collection parameters of `TypeDefinition`, `Direct`, `Union`,
  `Intersection`, `Condition` and `ConditionParameterType` are
  `params IEnumerable<T>`.
- **Text forms** implementing `IString`: `ObjectString` (`type:id`),
  `SubjectString` (`type:id`, `type:id#relation`, `type:*`),
  `SubjectFormString` (`type`, `type#relation`, `type:*`,
  `<form> with <condition>`) and `TupleString`
  (`object#relation@subject`, without the condition of a conditional
  tuple). An unknown `ISubject` or `ISubjectForm` implementation makes
  reading the text throw `ArgumentException`.
- All types throw `NotSupportedException` from `GetHashCode()` and
  `ToString()`.
- Dependencies on `Pure.Authorization.OpenFGA.Model.Abstractions`
  `0.1.0-preview.0.1.0`, `Pure.Primitives` `3.7.0` and
  `Pure.Primitives.String.Operations` `1.7.0`.
