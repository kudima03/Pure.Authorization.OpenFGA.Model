using Pure.Authorization.OpenFGA.Model.Abstractions.SubjectForm;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.SubjectForm;

/// <summary>
/// Every object of a type, written as a public-access wildcard. DSL: <c>user:*</c>.
/// </summary>
public sealed record WildcardForm : IWildcardForm
{
    public WildcardForm(IString type)
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
