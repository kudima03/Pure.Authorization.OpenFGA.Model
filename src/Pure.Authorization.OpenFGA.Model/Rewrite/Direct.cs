using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;
using Pure.Authorization.OpenFGA.Model.Abstractions.SubjectForm;

namespace Pure.Authorization.OpenFGA.Model.Rewrite;

/// <summary>
/// The relation can be written directly for the listed subject forms.
/// DSL: <c>[user, group#member]</c>.
/// </summary>
public sealed record Direct : IDirect
{
    public Direct(params IEnumerable<ISubjectForm> forms)
    {
        Forms = forms;
    }

    public IEnumerable<ISubjectForm> Forms { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
