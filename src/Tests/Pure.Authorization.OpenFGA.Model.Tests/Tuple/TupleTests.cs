using Pure.Authorization.OpenFGA.Model.Abstractions.Object;
using Pure.Authorization.OpenFGA.Model.Abstractions.Subject;
using Pure.Authorization.OpenFGA.Model.Abstractions.Tuple;
using Pure.Authorization.OpenFGA.Model.Subject;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using _Object = Pure.Authorization.OpenFGA.Model.Object.Object;
using _Tuple = Pure.Authorization.OpenFGA.Model.Tuple.Tuple;

namespace Pure.Authorization.OpenFGA.Model.Tests.Tuple;

public sealed record TupleTests
{
    [Fact]
    public void InitializeSubject()
    {
        ISubject subject = new TypedWildcard(new RandomString());

        ITuple tuple = new _Tuple(
            subject,
            new RandomString(),
            new _Object(new RandomString(), new RandomString())
        );

        Assert.Same(subject, tuple.Subject);
    }

    [Fact]
    public void InitializeRelation()
    {
        IString relation = new RandomString();

        ITuple tuple = new _Tuple(
            new TypedWildcard(new RandomString()),
            relation,
            new _Object(new RandomString(), new RandomString())
        );

        Assert.Same(relation, tuple.Relation);
    }

    [Fact]
    public void InitializeObject()
    {
        IObject @object = new _Object(new RandomString(), new RandomString());

        ITuple tuple = new _Tuple(
            new TypedWildcard(new RandomString()),
            new RandomString(),
            @object
        );

        Assert.Same(@object, tuple.Object);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Tuple(
                new TypedWildcard(new RandomString()),
                new RandomString(),
                new _Object(new RandomString(), new RandomString())
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Tuple(
                new TypedWildcard(new RandomString()),
                new RandomString(),
                new _Object(new RandomString(), new RandomString())
            ).ToString()
        );
    }
}
