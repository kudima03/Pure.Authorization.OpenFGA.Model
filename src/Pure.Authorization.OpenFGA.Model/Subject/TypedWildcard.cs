using Pure.Authorization.OpenFGA.Model.Abstractions.Subject;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Subject;

/// <summary>
/// Every object of a type, e.g. <c>user:*</c>.
/// </summary>
public sealed record TypedWildcard : ITypedWildcard
{
    public TypedWildcard(IString type)
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
