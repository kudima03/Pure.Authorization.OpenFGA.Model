using Pure.Authorization.OpenFGA.Model.Abstractions.Condition;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Condition;

/// <summary>
/// A typed parameter of a condition. DSL: <c>grant_time: timestamp</c>.
/// </summary>
public sealed record ConditionParameter : IConditionParameter
{
    public ConditionParameter(IString name, IConditionParameterType type)
    {
        Name = name;
        Type = type;
    }

    public IString Name { get; }

    public IConditionParameterType Type { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
