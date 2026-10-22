using Pure.Authorization.OpenFGA.Model.Abstractions.Condition;
using Pure.Authorization.OpenFGA.Model.Abstractions.Model;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Model;

/// <summary>
/// An OpenFGA authorization model: the schema version, the type definitions and the
/// conditions their relations may reference.
/// </summary>
public sealed record AuthorizationModel : IAuthorizationModel
{
    public AuthorizationModel(
        IString schemaVersion,
        IEnumerable<ITypeDefinition> types,
        IEnumerable<ICondition> conditions
    )
    {
        SchemaVersion = schemaVersion;
        Types = types;
        Conditions = conditions;
    }

    public IString SchemaVersion { get; }

    public IEnumerable<ITypeDefinition> Types { get; }

    public IEnumerable<ICondition> Conditions { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
