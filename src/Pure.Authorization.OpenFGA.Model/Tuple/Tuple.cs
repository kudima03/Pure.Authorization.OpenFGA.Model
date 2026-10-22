using Pure.Authorization.OpenFGA.Model.Abstractions.Object;
using Pure.Authorization.OpenFGA.Model.Abstractions.Subject;
using Pure.Authorization.OpenFGA.Model.Abstractions.Tuple;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Tuple;

/// <summary>
/// A relationship tuple: the subject holds the relation on the object.
/// </summary>
public sealed record Tuple : ITuple
{
    public Tuple(ISubject subject, IString relation, IObject @object)
    {
        Subject = subject;
        Relation = relation;
        Object = @object;
    }

    public ISubject Subject { get; }

    public IString Relation { get; }

    public IObject Object { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
