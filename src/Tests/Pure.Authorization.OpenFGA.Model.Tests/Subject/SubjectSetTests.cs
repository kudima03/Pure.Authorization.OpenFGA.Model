using Pure.Authorization.OpenFGA.Model.Abstractions.Object;
using Pure.Authorization.OpenFGA.Model.Abstractions.Subject;
using Pure.Authorization.OpenFGA.Model.Subject;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using _Object = Pure.Authorization.OpenFGA.Model.Object.Object;

namespace Pure.Authorization.OpenFGA.Model.Tests.Subject;

public sealed record SubjectSetTests
{
    [Fact]
    public void InitializeObject()
    {
        IObject @object = new _Object(new RandomString(), new RandomString());

        ISubjectSet subjectSet = new SubjectSet(@object, new RandomString());

        Assert.Same(@object, subjectSet.Object);
    }

    [Fact]
    public void InitializeRelation()
    {
        IString relation = new RandomString();

        ISubjectSet subjectSet = new SubjectSet(
            new _Object(new RandomString(), new RandomString()),
            relation
        );

        Assert.Same(relation, subjectSet.Relation);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new SubjectSet(
                new _Object(new RandomString(), new RandomString()),
                new RandomString()
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new SubjectSet(
                new _Object(new RandomString(), new RandomString()),
                new RandomString()
            ).ToString()
        );
    }
}
