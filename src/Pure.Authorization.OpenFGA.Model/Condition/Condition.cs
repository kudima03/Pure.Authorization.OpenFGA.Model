using Pure.Authorization.OpenFGA.Model.Abstractions.Condition;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Condition;

/// <summary>
/// A named CEL expression over typed parameters.
/// DSL: <c>condition non_expired(grant_time: timestamp) { ... }</c>.
/// </summary>
public sealed record Condition : ICondition
{
    public Condition(
        IString name,
        IString expression,
        params IEnumerable<IConditionParameter> parameters
    )
    {
        Name = name;
        Expression = expression;
        Parameters = parameters;
    }

    public IString Name { get; }

    public IString Expression { get; }

    public IEnumerable<IConditionParameter> Parameters { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
