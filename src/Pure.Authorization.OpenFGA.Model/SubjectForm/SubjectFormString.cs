using System.Collections;
using Pure.Authorization.OpenFGA.Model.Abstractions.SubjectForm;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.String;
using Pure.Primitives.String.Operations;
using String = Pure.Primitives.String.String;

namespace Pure.Authorization.OpenFGA.Model.SubjectForm;

/// <summary>
/// The OpenFGA DSL text form of a subject form, as written in a direct relation's type
/// restrictions:
/// <list type="bullet">
/// <item><description>
/// <c>type</c> for an <see cref="ITypeForm"/>, e.g. <c>user</c>;
/// </description></item>
/// <item><description>
/// <c>type#relation</c> for an <see cref="ISubjectSetForm"/>, e.g. <c>group#member</c>;
/// </description></item>
/// <item><description>
/// <c>type:*</c> for an <see cref="IWildcardForm"/>, e.g. <c>user:*</c>;
/// </description></item>
/// <item><description>
/// <c>&lt;form&gt; with condition</c> for an <see cref="IConditionalForm"/>,
/// e.g. <c>user with non_expired</c>.
/// </description></item>
/// </list>
/// Reading <see cref="TextValue"/> or enumerating throws <see cref="ArgumentException"/>
/// when the form is none of these variants.
/// </summary>
public sealed record SubjectFormString : IString
{
    private readonly ISubjectForm _form;

    public SubjectFormString(ISubjectForm form)
    {
        _form = form;
    }

    public string TextValue => Text.TextValue;

    private IString Text =>
        _form switch
        {
            ITypeForm typeForm => typeForm.Type,
            ISubjectSetForm subjectSetForm => new ConcatenatedString(
                subjectSetForm.Type,
                new HashString(),
                subjectSetForm.Relation
            ),
            IWildcardForm wildcardForm => new ColonJoinedString(
                wildcardForm.Type,
                new AsteriskString()
            ),
            IConditionalForm conditionalForm => new WhitespaceJoinedString(
                new SubjectFormString(conditionalForm.Form),
                new String("with"),
                conditionalForm.Condition
            ),
            _ => throw new ArgumentException(
                $"{_form.GetType().Name} is not a known {nameof(ISubjectForm)} variant."
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
