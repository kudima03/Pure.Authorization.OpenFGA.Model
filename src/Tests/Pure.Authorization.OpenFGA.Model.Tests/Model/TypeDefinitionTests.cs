using Pure.Authorization.OpenFGA.Model.Abstractions.Model;
using Pure.Authorization.OpenFGA.Model.Model;
using Pure.Authorization.OpenFGA.Model.Rewrite;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Model;

public sealed record TypeDefinitionTests
{
    [Fact]
    public void InitializeName()
    {
        IString name = new RandomString();

        ITypeDefinition type = new TypeDefinition(name);

        Assert.Same(name, type.Name);
    }

    [Fact]
    public void InitializeRelationsFromCollection()
    {
        IEnumerable<IRelationDefinition> relations =
        [
            new RelationDefinition(
                new RandomString(),
                new ComputedRelation(new RandomString())
            ),
        ];

        ITypeDefinition type = new TypeDefinition(new RandomString(), relations);

        Assert.Same(relations, type.Relations);
    }

    [Fact]
    public void InitializeRelationsFromArguments()
    {
        IRelationDefinition viewer = new RelationDefinition(
            new RandomString(),
            new ComputedRelation(new RandomString())
        );
        IRelationDefinition editor = new RelationDefinition(
            new RandomString(),
            new ComputedRelation(new RandomString())
        );

        ITypeDefinition type = new TypeDefinition(new RandomString(), viewer, editor);

        Assert.Collection(
            type.Relations,
            relation => Assert.Same(viewer, relation),
            relation => Assert.Same(editor, relation)
        );
    }

    [Fact]
    public void InitializeWithoutRelations()
    {
        ITypeDefinition type = new TypeDefinition(new RandomString());

        Assert.Empty(type.Relations);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TypeDefinition(new RandomString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TypeDefinition(new RandomString()).ToString()
        );
    }
}
