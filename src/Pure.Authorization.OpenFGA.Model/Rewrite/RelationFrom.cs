using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Rewrite;

/// <summary>
/// Whoever holds a relation on the objects related through a tupleset relation.
/// DSL: <c>viewer from parent</c>.
/// </summary>
public sealed record RelationFrom : IRelationFrom
{
    public RelationFrom(IString relation, IString tupleset)
    {
        Relation = relation;
        Tupleset = tupleset;
    }

    public IString Relation { get; }

    public IString Tupleset { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
