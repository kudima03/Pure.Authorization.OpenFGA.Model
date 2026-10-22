using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;
using Pure.Authorization.OpenFGA.Model.Rewrite;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Rewrite;

public sealed record ComputedRelationTests
{
    [Fact]
    public void InitializeRelation()
    {
        IString relation = new RandomString();

        IComputedRelation computed = new ComputedRelation(relation);

        Assert.Same(relation, computed.Relation);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ComputedRelation(new RandomString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ComputedRelation(new RandomString()).ToString()
        );
    }
}
