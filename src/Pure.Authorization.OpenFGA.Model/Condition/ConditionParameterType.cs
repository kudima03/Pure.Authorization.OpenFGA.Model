using Pure.Authorization.OpenFGA.Model.Abstractions.Condition;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Condition;

/// <summary>
/// The type of a condition parameter. DSL: <c>timestamp</c>, <c>list&lt;string&gt;</c>.
/// </summary>
public sealed record ConditionParameterType : IConditionParameterType
{
    public ConditionParameterType(
        IString name,
        params IEnumerable<IConditionParameterType> genericTypes
    )
    {
        Name = name;
        GenericTypes = genericTypes;
    }

    public IString Name { get; }

    public IEnumerable<IConditionParameterType> GenericTypes { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
