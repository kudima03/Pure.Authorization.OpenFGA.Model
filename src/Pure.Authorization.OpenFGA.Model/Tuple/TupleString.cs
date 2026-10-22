using System.Collections;
using Pure.Authorization.OpenFGA.Model.Abstractions.Tuple;
using Pure.Authorization.OpenFGA.Model.Object;
using Pure.Authorization.OpenFGA.Model.Subject;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.String;
using Pure.Primitives.String.Operations;

namespace Pure.Authorization.OpenFGA.Model.Tuple;

/// <summary>
/// The OpenFGA text form of a relationship tuple: <c>object#relation@subject</c>,
/// e.g. <c>document:1#viewer@group:eng#member</c>. The object is written as by
/// <see cref="ObjectString"/> and the subject as by <see cref="SubjectString"/>.
/// The condition of an <see cref="IConditionalTuple"/> is not part of this form: a
/// conditional tuple is written exactly like the tuple it decorates.
/// </summary>
public sealed record TupleString : IString
{
    private readonly ITuple _tuple;

    public TupleString(ITuple tuple)
    {
        _tuple = tuple;
    }

    public string TextValue => Text.TextValue;

    private IString Text =>
        new ConcatenatedString(
            new ObjectString(_tuple.Object),
            new HashString(),
            _tuple.Relation,
            new AtString(),
            new SubjectString(_tuple.Subject)
        );

    public IEnumerator<IChar> GetEnumerator()
    {
        return Text.GetEnumerator();
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
