using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;
using Pure.Authorization.OpenFGA.Model.Abstractions.SubjectForm;
using Pure.Authorization.OpenFGA.Model.Rewrite;
using Pure.Authorization.OpenFGA.Model.SubjectForm;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Rewrite;

public sealed record DirectTests
{
    [Fact]
    public void InitializeFormsFromCollection()
    {
        IEnumerable<ISubjectForm> forms =
        [
            new TypeForm(new RandomString()),
            new WildcardForm(new RandomString()),
        ];

        IDirect direct = new Direct(forms);

        Assert.Same(forms, direct.Forms);
    }

    [Fact]
    public void InitializeFormsFromArguments()
    {
        ISubjectForm user = new TypeForm(new RandomString());
        ISubjectForm member = new SubjectSetForm(new RandomString(), new RandomString());

        IDirect direct = new Direct(user, member);

        Assert.Collection(
            direct.Forms,
            form => Assert.Same(user, form),
            form => Assert.Same(member, form)
        );
    }

    [Fact]
    public void InitializeWithoutForms()
    {
        IDirect direct = new Direct();

        Assert.Empty(direct.Forms);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() => new Direct().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() => new Direct().ToString());
    }
}
