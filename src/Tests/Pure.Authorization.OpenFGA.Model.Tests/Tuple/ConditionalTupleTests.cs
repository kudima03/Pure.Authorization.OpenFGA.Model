using System.Text.Json.Nodes;
using Pure.Authorization.OpenFGA.Model.Abstractions.Tuple;
using Pure.Authorization.OpenFGA.Model.Subject;
using Pure.Authorization.OpenFGA.Model.Tuple;
using Pure.Primitives.Random.String;
using _Object = Pure.Authorization.OpenFGA.Model.Object.Object;
using _Tuple = Pure.Authorization.OpenFGA.Model.Tuple.Tuple;

namespace Pure.Authorization.OpenFGA.Model.Tests.Tuple;

public sealed record ConditionalTupleTests
{
    [Fact]
    public void DelegatesSubjectToWrappedTuple()
    {
        ITuple tuple = new _Tuple(
            new TypedWildcard(new RandomString()),
            new RandomString(),
            new _Object(new RandomString(), new RandomString())
        );

        IConditionalTuple conditional = new ConditionalTuple(
            tuple,
            new RelationshipCondition(new RandomString(), new JsonObject())
        );

        Assert.Same(tuple.Subject, conditional.Subject);
    }

    [Fact]
    public void DelegatesRelationToWrappedTuple()
    {
        ITuple tuple = new _Tuple(
            new TypedWildcard(new RandomString()),
            new RandomString(),
            new _Object(new RandomString(), new RandomString())
        );

        IConditionalTuple conditional = new ConditionalTuple(
            tuple,
            new RelationshipCondition(new RandomString(), new JsonObject())
        );

        Assert.Same(tuple.Relation, conditional.Relation);
    }

    [Fact]
    public void DelegatesObjectToWrappedTuple()
    {
        ITuple tuple = new _Tuple(
            new TypedWildcard(new RandomString()),
            new RandomString(),
            new _Object(new RandomString(), new RandomString())
        );

        IConditionalTuple conditional = new ConditionalTuple(
            tuple,
            new RelationshipCondition(new RandomString(), new JsonObject())
        );

        Assert.Same(tuple.Object, conditional.Object);
    }

    [Fact]
    public void InitializeCondition()
    {
        IRelationshipCondition condition = new RelationshipCondition(
            new RandomString(),
            new JsonObject()
        );

        IConditionalTuple conditional = new ConditionalTuple(
            new _Tuple(
                new TypedWildcard(new RandomString()),
                new RandomString(),
                new _Object(new RandomString(), new RandomString())
            ),
            condition
        );

        Assert.Same(condition, conditional.Condition);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ConditionalTuple(
                new _Tuple(
                    new TypedWildcard(new RandomString()),
                    new RandomString(),
                    new _Object(new RandomString(), new RandomString())
                ),
                new RelationshipCondition(new RandomString(), new JsonObject())
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ConditionalTuple(
                new _Tuple(
                    new TypedWildcard(new RandomString()),
                    new RandomString(),
                    new _Object(new RandomString(), new RandomString())
                ),
                new RelationshipCondition(new RandomString(), new JsonObject())
            ).ToString()
        );
    }
}
