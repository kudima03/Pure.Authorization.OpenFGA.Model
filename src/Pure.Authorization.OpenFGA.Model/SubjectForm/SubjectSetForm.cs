using Pure.Authorization.OpenFGA.Model.Abstractions.SubjectForm;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.SubjectForm;

/// <summary>
/// The set of subjects holding a relation on an object of a type.
/// DSL: <c>group#member</c>.
/// </summary>
public sealed record SubjectSetForm : ISubjectSetForm
{
    public SubjectSetForm(IString type, IString relation)
    {
        Type = type;
        Relation = relation;
    }

    public IString Type { get; }

    public IString Relation { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
