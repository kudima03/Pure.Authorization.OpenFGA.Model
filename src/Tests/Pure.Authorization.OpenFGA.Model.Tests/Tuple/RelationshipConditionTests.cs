using System.Text.Json.Nodes;
using Pure.Authorization.OpenFGA.Model.Abstractions.Tuple;
using Pure.Authorization.OpenFGA.Model.Tuple;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Tuple;

public sealed record RelationshipConditionTests
{
    [Fact]
    public void InitializeName()
    {
        IString name = new RandomString();

        IRelationshipCondition condition = new RelationshipCondition(
            name,
            new JsonObject()
        );

        Assert.Same(name, condition.Name);
    }

    [Fact]
    public void InitializeContext()
    {
        JsonNode context = new JsonObject
        {
            ["grant_time"] = "2026-01-01T00:00:00Z",
            ["duration"] = "1h",
        };

        IRelationshipCondition condition = new RelationshipCondition(
            new RandomString(),
            context
        );

        Assert.Same(context, condition.Context);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RelationshipCondition(new RandomString(), new JsonObject()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RelationshipCondition(new RandomString(), new JsonObject()).ToString()
        );
    }
}
