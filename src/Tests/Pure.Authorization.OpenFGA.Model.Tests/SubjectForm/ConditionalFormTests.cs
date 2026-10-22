using Pure.Authorization.OpenFGA.Model.Abstractions.SubjectForm;
using Pure.Authorization.OpenFGA.Model.SubjectForm;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.SubjectForm;

public sealed record ConditionalFormTests
{
    [Fact]
    public void InitializeForm()
    {
        ISubjectForm form = new TypeForm(new RandomString());

        IConditionalForm conditional = new ConditionalForm(form, new RandomString());

        Assert.Same(form, conditional.Form);
    }

    [Fact]
    public void InitializeCondition()
    {
        IString condition = new RandomString();

        IConditionalForm conditional = new ConditionalForm(
            new TypeForm(new RandomString()),
            condition
        );

        Assert.Same(condition, conditional.Condition);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ConditionalForm(
                new TypeForm(new RandomString()),
                new RandomString()
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ConditionalForm(
                new TypeForm(new RandomString()),
                new RandomString()
            ).ToString()
        );
    }
}
