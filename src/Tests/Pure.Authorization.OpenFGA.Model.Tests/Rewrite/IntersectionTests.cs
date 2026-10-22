using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;
using Pure.Authorization.OpenFGA.Model.Rewrite;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Rewrite;

public sealed record IntersectionTests
{
    [Fact]
    public void InitializeChildrenFromCollection()
    {
        IEnumerable<IRewrite> children =
        [
            new ComputedRelation(new RandomString()),
            new ComputedRelation(new RandomString()),
        ];

        IIntersection intersection = new Intersection(children);

        Assert.Same(children, intersection.Children);
    }

    [Fact]
    public void InitializeChildrenFromArguments()
    {
        IRewrite direct = new Direct();
        IRewrite computed = new ComputedRelation(new RandomString());
        IRewrite from = new RelationFrom(new RandomString(), new RandomString());

        IIntersection intersection = new Intersection(direct, computed, from);

        Assert.Collection(
            intersection.Children,
            child => Assert.Same(direct, child),
            child => Assert.Same(computed, child),
            child => Assert.Same(from, child)
        );
    }

    [Fact]
    public void InitializeWithoutChildren()
    {
        IIntersection intersection = new Intersection();

        Assert.Empty(intersection.Children);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() => new Intersection().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() => new Intersection().ToString());
    }
}
