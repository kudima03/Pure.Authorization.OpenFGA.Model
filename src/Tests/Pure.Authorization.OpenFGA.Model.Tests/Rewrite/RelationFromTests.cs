using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;
using Pure.Authorization.OpenFGA.Model.Rewrite;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Rewrite;

public sealed record RelationFromTests
{
    [Fact]
    public void InitializeRelation()
    {
        IString relation = new RandomString();

        IRelationFrom from = new RelationFrom(relation, new RandomString());

        Assert.Same(relation, from.Relation);
    }

    [Fact]
    public void InitializeTupleset()
    {
        IString tupleset = new RandomString();

        IRelationFrom from = new RelationFrom(new RandomString(), tupleset);

        Assert.Same(tupleset, from.Tupleset);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RelationFrom(new RandomString(), new RandomString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RelationFrom(new RandomString(), new RandomString()).ToString()
        );
    }
}
