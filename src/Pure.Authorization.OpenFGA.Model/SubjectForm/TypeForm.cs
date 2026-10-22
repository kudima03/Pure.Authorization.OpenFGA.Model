using Pure.Authorization.OpenFGA.Model.Abstractions.SubjectForm;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.SubjectForm;

/// <summary>
/// Any single object of a type. DSL: <c>user</c>.
/// </summary>
public sealed record TypeForm : ITypeForm
{
    public TypeForm(IString type)
    {
        Type = type;
    }

    public IString Type { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
