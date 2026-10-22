using Pure.Authorization.OpenFGA.Model.Abstractions.Object;
using Pure.Authorization.OpenFGA.Model.Abstractions.Subject;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Subject;

/// <summary>
/// Every subject holding a relation on an object, e.g. <c>group:1#member</c>.
/// </summary>
public sealed record SubjectSet : ISubjectSet
{
    public SubjectSet(IObject @object, IString relation)
    {
        Object = @object;
        Relation = relation;
    }

    public IObject Object { get; }

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
