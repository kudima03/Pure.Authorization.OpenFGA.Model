using Pure.Authorization.OpenFGA.Model.Abstractions.Subject;
using Pure.Authorization.OpenFGA.Model.Subject;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Subject;

public sealed record TypedWildcardTests
{
    [Fact]
    public void InitializeType()
    {
        IString type = new RandomString();

        ITypedWildcard wildcard = new TypedWildcard(type);

        Assert.Same(type, wildcard.Type);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TypedWildcard(new RandomString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TypedWildcard(new RandomString()).ToString()
        );
    }
}
