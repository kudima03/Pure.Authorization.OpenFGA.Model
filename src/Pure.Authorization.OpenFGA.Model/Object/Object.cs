using Pure.Authorization.OpenFGA.Model.Abstractions.Object;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Object;

/// <summary>
/// An object of a type, e.g. <c>document:1</c>. Also usable as a tuple subject.
/// </summary>
public sealed record Object : IObject
{
    public Object(IString type, IString id)
    {
        Type = type;
        Id = id;
    }

    public IString Type { get; }

    public IString Id { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
