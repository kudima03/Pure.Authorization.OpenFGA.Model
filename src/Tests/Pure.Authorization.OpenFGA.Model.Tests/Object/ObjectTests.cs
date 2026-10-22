using Pure.Authorization.OpenFGA.Model.Abstractions.Object;
using Pure.Authorization.OpenFGA.Model.Abstractions.Subject;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using _Object = Pure.Authorization.OpenFGA.Model.Object.Object;

namespace Pure.Authorization.OpenFGA.Model.Tests.Object;

public sealed record ObjectTests
{
    [Fact]
    public void InitializeType()
    {
        IString type = new RandomString();

        IObject @object = new _Object(type, new RandomString());

        Assert.Same(type, @object.Type);
    }

    [Fact]
    public void InitializeId()
    {
        IString id = new RandomString();

        IObject @object = new _Object(new RandomString(), id);

        Assert.Same(id, @object.Id);
    }

    [Fact]
    public void ActsAsSubject()
    {
        ISubject subject = new _Object(new RandomString(), new RandomString());

        _ = Assert.IsType<IObject>(subject, exactMatch: false);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Object(new RandomString(), new RandomString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Object(new RandomString(), new RandomString()).ToString()
        );
    }
}
