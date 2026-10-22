using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Rewrite;

/// <summary>
/// Whoever holds another relation on the same object. DSL: <c>editor</c>.
/// </summary>
public sealed record ComputedRelation : IComputedRelation
{
    public ComputedRelation(IString relation)
    {
        Relation = relation;
    }

    public IString Relation { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
