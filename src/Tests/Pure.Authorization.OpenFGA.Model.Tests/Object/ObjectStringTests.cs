using System.Collections;
using Pure.Authorization.OpenFGA.Model.Object;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using _Object = Pure.Authorization.OpenFGA.Model.Object.Object;
using String = Pure.Primitives.String.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Object;

public sealed record ObjectStringTests
{
    [Fact]
    public void WritesTypeAndIdSeparatedByColon()
    {
        IString text = new ObjectString(
            new _Object(new String("document"), new String("roadmap"))
        );

        Assert.Equal("document:roadmap", text.TextValue);
    }

    [Fact]
    public void WritesEmptyIdAsIs()
    {
        IString text = new ObjectString(
            new _Object(new String("document"), new String(string.Empty))
        );

        Assert.Equal("document:", text.TextValue);
    }

    [Fact]
    public void WritesEmptyTypeAsIs()
    {
        IString text = new ObjectString(
            new _Object(new String(string.Empty), new String("1"))
        );

        Assert.Equal(":1", text.TextValue);
    }

    [Fact]
    public void DoesNotEscapeSeparatorsInParts()
    {
        IString text = new ObjectString(
            new _Object(new String("document"), new String("a:b#c@d"))
        );

        Assert.Equal("document:a:b#c@d", text.TextValue);
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        IString text = new ObjectString(
            new _Object(new String("document"), new String("1"))
        );

        Assert.Equal("document:1", string.Concat(text.Select(x => x.CharValue)));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable text = new ObjectString(
            new _Object(new String("document"), new String("1"))
        );

        ICollection<char> symbols = [];

        foreach (object symbol in text)
        {
            symbols.Add(((IChar)symbol).CharValue);
        }

        Assert.Equal("document:1", string.Concat(symbols));
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ObjectString(
                new _Object(new String("document"), new String("1"))
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ObjectString(
                new _Object(new String("document"), new String("1"))
            ).ToString()
        );
    }
}
