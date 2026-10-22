using Pure.Authorization.OpenFGA.Model.Abstractions.Model;
using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;
using Pure.Authorization.OpenFGA.Model.Model;
using Pure.Authorization.OpenFGA.Model.Rewrite;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Model;

public sealed record RelationDefinitionTests
{
    [Fact]
    public void InitializeName()
    {
        IString name = new RandomString();

        IRelationDefinition relation = new RelationDefinition(
            name,
            new ComputedRelation(new RandomString())
        );

        Assert.Same(name, relation.Name);
    }

    [Fact]
    public void InitializeRewrite()
    {
        IRewrite rewrite = new ComputedRelation(new RandomString());

        IRelationDefinition relation = new RelationDefinition(
            new RandomString(),
            rewrite
        );

        Assert.Same(rewrite, relation.Rewrite);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RelationDefinition(
                new RandomString(),
                new ComputedRelation(new RandomString())
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RelationDefinition(
                new RandomString(),
                new ComputedRelation(new RandomString())
            ).ToString()
        );
    }
}
