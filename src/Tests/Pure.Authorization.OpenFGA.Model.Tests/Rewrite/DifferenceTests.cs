using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;
using Pure.Authorization.OpenFGA.Model.Rewrite;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Rewrite;

public sealed record DifferenceTests
{
    [Fact]
    public void InitializeBase()
    {
        IRewrite @base = new ComputedRelation(new RandomString());

        IDifference difference = new Difference(
            @base,
            new ComputedRelation(new RandomString())
        );

        Assert.Same(@base, difference.Base);
    }

    [Fact]
    public void InitializeSubtract()
    {
        IRewrite subtract = new ComputedRelation(new RandomString());

        IDifference difference = new Difference(
            new ComputedRelation(new RandomString()),
            subtract
        );

        Assert.Same(subtract, difference.Subtract);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new Difference(new Direct(), new Direct()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new Difference(new Direct(), new Direct()).ToString()
        );
    }
}
