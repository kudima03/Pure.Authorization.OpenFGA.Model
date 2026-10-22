using System.Collections;
using Pure.Authorization.OpenFGA.Model.Abstractions.Object;
using Pure.Authorization.OpenFGA.Model.Abstractions.Subject;
using Pure.Authorization.OpenFGA.Model.Object;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.String;
using Pure.Primitives.String.Operations;

namespace Pure.Authorization.OpenFGA.Model.Subject;

/// <summary>
/// The OpenFGA text form of a tuple subject:
/// <list type="bullet">
/// <item><description>
/// <c>type:id</c> for an <see cref="IObject"/>, e.g. <c>user:anne</c>;
/// </description></item>
/// <item><description>
/// <c>type:id#relation</c> for an <see cref="ISubjectSet"/>,
/// e.g. <c>group:eng#member</c>;
/// </description></item>
/// <item><description>
/// <c>type:*</c> for an <see cref="ITypedWildcard"/>, e.g. <c>user:*</c>.
/// </description></item>
/// </list>
/// Reading <see cref="TextValue"/> or enumerating throws <see cref="ArgumentException"/>
/// when the subject is none of these variants.
/// </summary>
public sealed record SubjectString : IString
{
    private readonly ISubject _subject;

    public SubjectString(ISubject subject)
    {
        _subject = subject;
    }

    public string TextValue => Text.TextValue;

    private IString Text =>
        _subject switch
        {
            IObject @object => new ObjectString(@object),
            ISubjectSet subjectSet => new ConcatenatedString(
                new ObjectString(subjectSet.Object),
                new HashString(),
                subjectSet.Relation
            ),
            ITypedWildcard wildcard => new ColonJoinedString(
                wildcard.Type,
                new AsteriskString()
            ),
            _ => throw new ArgumentException(
                $"{_subject.GetType().Name} is not a known {nameof(ISubject)} variant."
            ),
        };

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
