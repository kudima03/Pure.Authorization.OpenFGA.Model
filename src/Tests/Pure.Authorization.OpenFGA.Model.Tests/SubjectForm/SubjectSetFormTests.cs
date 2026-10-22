using Pure.Authorization.OpenFGA.Model.Abstractions.SubjectForm;
using Pure.Authorization.OpenFGA.Model.SubjectForm;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.SubjectForm;

public sealed record SubjectSetFormTests
{
    [Fact]
    public void InitializeType()
    {
        IString type = new RandomString();

        ISubjectSetForm form = new SubjectSetForm(type, new RandomString());

        Assert.Same(type, form.Type);
    }

    [Fact]
    public void InitializeRelation()
    {
        IString relation = new RandomString();

        ISubjectSetForm form = new SubjectSetForm(new RandomString(), relation);

        Assert.Same(relation, form.Relation);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new SubjectSetForm(new RandomString(), new RandomString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new SubjectSetForm(new RandomString(), new RandomString()).ToString()
        );
    }
}
