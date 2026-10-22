using Pure.Authorization.OpenFGA.Model.Abstractions.Object;
using Pure.Authorization.OpenFGA.Model.Abstractions.Subject;
using Pure.Authorization.OpenFGA.Model.Abstractions.Tuple;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Tuple;

/// <summary>
/// A tuple that holds only while its condition evaluates to true. It decorates a tuple:
/// <see cref="Subject"/>, <see cref="Relation"/> and <see cref="Object"/> come from the
/// wrapped tuple, and only the condition is added.
/// </summary>
public sealed record ConditionalTuple : IConditionalTuple
{
    private readonly ITuple _tuple;

    public ConditionalTuple(ITuple tuple, IRelationshipCondition condition)
    {
        _tuple = tuple;
        Condition = condition;
    }

    public ISubject Subject => _tuple.Subject;

    public IString Relation => _tuple.Relation;

    public IObject Object => _tuple.Object;

    public IRelationshipCondition Condition { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
