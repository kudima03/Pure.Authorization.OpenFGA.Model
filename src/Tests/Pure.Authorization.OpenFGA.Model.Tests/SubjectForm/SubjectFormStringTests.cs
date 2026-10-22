using System.Collections;
using Pure.Authorization.OpenFGA.Model.SubjectForm;
using Pure.Authorization.OpenFGA.Model.Tests.Fakes;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using String = Pure.Primitives.String.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.SubjectForm;

public sealed record SubjectFormStringTests
{
    [Fact]
    public void WritesTypeFormAsType()
    {
        IString text = new SubjectFormString(new TypeForm(new String("user")));

        Assert.Equal("user", text.TextValue);
    }

    [Fact]
    public void WritesSubjectSetFormAsTypeAndRelation()
    {
        IString text = new SubjectFormString(
            new SubjectSetForm(new String("group"), new String("member"))
        );

        Assert.Equal("group#member", text.TextValue);
    }

    [Fact]
    public void WritesWildcardFormAsTypeAndAsterisk()
    {
        IString text = new SubjectFormString(new WildcardForm(new String("user")));

        Assert.Equal("user:*", text.TextValue);
    }

    [Fact]
    public void WritesConditionalTypeFormWithCondition()
    {
        IString text = new SubjectFormString(
            new ConditionalForm(
                new TypeForm(new String("user")),
                new String("non_expired")
            )
        );

        Assert.Equal("user with non_expired", text.TextValue);
    }

    [Fact]
    public void WritesConditionalSubjectSetFormWithCondition()
    {
        IString text = new SubjectFormString(
            new ConditionalForm(
                new SubjectSetForm(new String("group"), new String("member")),
                new String("in_region")
            )
        );

        Assert.Equal("group#member with in_region", text.TextValue);
    }

    [Fact]
    public void WritesConditionalWildcardFormWithCondition()
    {
        IString text = new SubjectFormString(
            new ConditionalForm(
                new WildcardForm(new String("user")),
                new String("non_expired")
            )
        );

        Assert.Equal("user:* with non_expired", text.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnUnknownSubjectFormVariant()
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            new SubjectFormString(new UnknownSubjectForm()).TextValue
        );

        Assert.Equal(
            "UnknownSubjectForm is not a known ISubjectForm variant.",
            exception.Message
        );
    }

    [Fact]
    public void ThrowsExceptionOnConditionalUnknownSubjectFormVariant()
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            new SubjectFormString(
                new ConditionalForm(new UnknownSubjectForm(), new String("non_expired"))
            ).TextValue
        );

        Assert.Equal(
            "UnknownSubjectForm is not a known ISubjectForm variant.",
            exception.Message
        );
    }

    [Fact]
    public void ThrowsExceptionOnEnumeratingUnknownSubjectFormVariant()
    {
        _ = Assert.Throws<ArgumentException>(() =>
            new SubjectFormString(new UnknownSubjectForm()).GetEnumerator()
        );
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        IString text = new SubjectFormString(
            new ConditionalForm(
                new TypeForm(new String("user")),
                new String("non_expired")
            )
        );

        Assert.Equal(
            "user with non_expired",
            string.Concat(text.Select(x => x.CharValue))
        );
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable text = new SubjectFormString(
            new SubjectSetForm(new String("group"), new String("member"))
        );

        ICollection<char> symbols = [];

        foreach (object symbol in text)
        {
            symbols.Add(((IChar)symbol).CharValue);
        }

        Assert.Equal("group#member", string.Concat(symbols));
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new SubjectFormString(new TypeForm(new String("user"))).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new SubjectFormString(new TypeForm(new String("user"))).ToString()
        );
    }
}
