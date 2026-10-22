using Pure.Authorization.OpenFGA.Model.Abstractions.SubjectForm;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.SubjectForm;

/// <summary>
/// A subject form that may only be written together with a condition.
/// DSL: <c>user with non_expired</c>.
/// </summary>
public sealed record ConditionalForm : IConditionalForm
{
    public ConditionalForm(ISubjectForm form, IString condition)
    {
        Form = form;
        Condition = condition;
    }

    public ISubjectForm Form { get; }

    public IString Condition { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
