using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;
using Pure.Authorization.OpenFGA.Model.Rewrite;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Rewrite;

public sealed record UnionTests
{
    [Fact]
    public void InitializeChildrenFromCollection()
    {
        IEnumerable<IRewrite> children =
        [
            new ComputedRelation(new RandomString()),
            new ComputedRelation(new RandomString()),
        ];

        IUnion union = new Union(children);

        Assert.Same(children, union.Children);
    }

    [Fact]
    public void InitializeChildrenFromArguments()
    {
        IRewrite direct = new Direct();
        IRewrite computed = new ComputedRelation(new RandomString());
        IRewrite from = new RelationFrom(new RandomString(), new RandomString());

        IUnion union = new Union(direct, computed, from);

        Assert.Collection(
            union.Children,
            child => Assert.Same(direct, child),
            child => Assert.Same(computed, child),
            child => Assert.Same(from, child)
        );
    }

    [Fact]
    public void InitializeWithoutChildren()
    {
        IUnion union = new Union();

        Assert.Empty(union.Children);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() => new Union().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() => new Union().ToString());
    }
}
