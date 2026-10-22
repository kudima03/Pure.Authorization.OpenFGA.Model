using Pure.Authorization.OpenFGA.Model.Abstractions.SubjectForm;
using Pure.Authorization.OpenFGA.Model.SubjectForm;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.SubjectForm;

public sealed record TypeFormTests
{
    [Fact]
    public void InitializeType()
    {
        IString type = new RandomString();

        ITypeForm form = new TypeForm(type);

        Assert.Same(type, form.Type);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TypeForm(new RandomString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TypeForm(new RandomString()).ToString()
        );
    }
}
