using System.Collections;
using System.Text.Json.Nodes;
using Pure.Authorization.OpenFGA.Model.Subject;
using Pure.Authorization.OpenFGA.Model.Tests.Fakes;
using Pure.Authorization.OpenFGA.Model.Tuple;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using _Object = Pure.Authorization.OpenFGA.Model.Object.Object;
using _Tuple = Pure.Authorization.OpenFGA.Model.Tuple.Tuple;
using String = Pure.Primitives.String.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Tuple;

public sealed record TupleStringTests
{
    [Fact]
    public void WritesTupleWithObjectSubject()
    {
        IString text = new TupleString(
            new _Tuple(
                new _Object(new String("user"), new String("anne")),
                new String("viewer"),
                new _Object(new String("document"), new String("1"))
            )
        );

        Assert.Equal("document:1#viewer@user:anne", text.TextValue);
    }

    [Fact]
    public void WritesTupleWithSubjectSetSubject()
    {
        IString text = new TupleString(
            new _Tuple(
                new SubjectSet(
                    new _Object(new String("group"), new String("eng")),
                    new String("member")
                ),
                new String("viewer"),
                new _Object(new String("document"), new String("1"))
            )
        );

        Assert.Equal("document:1#viewer@group:eng#member", text.TextValue);
    }

    [Fact]
    public void WritesTupleWithTypedWildcardSubject()
    {
        IString text = new TupleString(
            new _Tuple(
                new TypedWildcard(new String("user")),
                new String("viewer"),
                new _Object(new String("document"), new String("1"))
            )
        );

        Assert.Equal("document:1#viewer@user:*", text.TextValue);
    }

    [Fact]
    public void WritesConditionalTupleWithoutCondition()
    {
        IString text = new TupleString(
            new ConditionalTuple(
                new _Tuple(
                    new _Object(new String("user"), new String("anne")),
                    new String("viewer"),
                    new _Object(new String("document"), new String("1"))
                ),
                new RelationshipCondition(
                    new String("non_expired"),
                    new JsonObject { ["duration"] = "1h" }
                )
            )
        );

        Assert.Equal("document:1#viewer@user:anne", text.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnUnknownSubjectVariant()
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            new TupleString(
                new _Tuple(
                    new UnknownSubject(),
                    new String("viewer"),
                    new _Object(new String("document"), new String("1"))
                )
            ).TextValue
        );

        Assert.Equal(
            "UnknownSubject is not a known ISubject variant.",
            exception.Message
        );
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        IString text = new TupleString(
            new _Tuple(
                new TypedWildcard(new String("user")),
                new String("viewer"),
                new _Object(new String("document"), new String("1"))
            )
        );

        Assert.Equal(
            "document:1#viewer@user:*",
            string.Concat(text.Select(x => x.CharValue))
        );
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable text = new TupleString(
            new _Tuple(
                new TypedWildcard(new String("user")),
                new String("viewer"),
                new _Object(new String("document"), new String("1"))
            )
        );

        ICollection<char> symbols = [];

        foreach (object symbol in text)
        {
            symbols.Add(((IChar)symbol).CharValue);
        }

        Assert.Equal("document:1#viewer@user:*", string.Concat(symbols));
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TupleString(
                new _Tuple(
                    new TypedWildcard(new String("user")),
                    new String("viewer"),
                    new _Object(new String("document"), new String("1"))
                )
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new TupleString(
                new _Tuple(
                    new TypedWildcard(new String("user")),
                    new String("viewer"),
                    new _Object(new String("document"), new String("1"))
                )
            ).ToString()
        );
    }
}
