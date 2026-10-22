using System.Text.Json.Nodes;
using Pure.Authorization.OpenFGA.Model.Abstractions.Tuple;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Tuple;

/// <summary>
/// The condition attached to a tuple: a condition name and its stored context.
/// </summary>
public sealed record RelationshipCondition : IRelationshipCondition
{
    public RelationshipCondition(IString name, JsonNode context)
    {
        Name = name;
        Context = context;
    }

    public IString Name { get; }

    public JsonNode Context { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
