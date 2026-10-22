using System.Collections;
using Pure.Authorization.OpenFGA.Model.Subject;
using Pure.Authorization.OpenFGA.Model.Tests.Fakes;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using _Object = Pure.Authorization.OpenFGA.Model.Object.Object;
using String = Pure.Primitives.String.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Subject;

public sealed record SubjectStringTests
{
    [Fact]
    public void WritesObjectAsTypeAndId()
    {
        IString text = new SubjectString(
            new _Object(new String("user"), new String("anne"))
        );

        Assert.Equal("user:anne", text.TextValue);
    }

    [Fact]
    public void WritesSubjectSetAsObjectAndRelation()
    {
        IString text = new SubjectString(
            new SubjectSet(
                new _Object(new String("group"), new String("eng")),
                new String("member")
            )
        );

        Assert.Equal("group:eng#member", text.TextValue);
    }

    [Fact]
    public void WritesTypedWildcardAsTypeAndAsterisk()
    {
        IString text = new SubjectString(new TypedWildcard(new String("user")));

        Assert.Equal("user:*", text.TextValue);
    }

    [Fact]
    public void WritesEmptyRelationOfSubjectSetAsIs()
    {
        IString text = new SubjectString(
            new SubjectSet(
                new _Object(new String("group"), new String("eng")),
                new String(string.Empty)
            )
        );

        Assert.Equal("group:eng#", text.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnUnknownSubjectVariant()
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            new SubjectString(new UnknownSubject()).TextValue
        );

        Assert.Equal(
            "UnknownSubject is not a known ISubject variant.",
            exception.Message
        );
    }

    [Fact]
    public void ThrowsExceptionOnEnumeratingUnknownSubjectVariant()
    {
        _ = Assert.Throws<ArgumentException>(() =>
            new SubjectString(new UnknownSubject()).GetEnumerator()
        );
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        IString text = new SubjectString(
            new SubjectSet(
                new _Object(new String("group"), new String("eng")),
                new String("member")
            )
        );

        Assert.Equal("group:eng#member", string.Concat(text.Select(x => x.CharValue)));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable text = new SubjectString(new TypedWildcard(new String("user")));

        ICollection<char> symbols = [];

        foreach (object symbol in text)
        {
            symbols.Add(((IChar)symbol).CharValue);
        }

        Assert.Equal("user:*", string.Concat(symbols));
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new SubjectString(new TypedWildcard(new String("user"))).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new SubjectString(new TypedWildcard(new String("user"))).ToString()
        );
    }
}
