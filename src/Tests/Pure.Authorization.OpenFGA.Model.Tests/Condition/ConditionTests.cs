using Pure.Authorization.OpenFGA.Model.Abstractions.Condition;
using Pure.Authorization.OpenFGA.Model.Condition;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using _Condition = Pure.Authorization.OpenFGA.Model.Condition.Condition;

namespace Pure.Authorization.OpenFGA.Model.Tests.Condition;

public sealed record ConditionTests
{
    [Fact]
    public void InitializeName()
    {
        IString name = new RandomString();

        ICondition condition = new _Condition(name, new RandomString());

        Assert.Same(name, condition.Name);
    }

    [Fact]
    public void InitializeExpression()
    {
        IString expression = new RandomString();

        ICondition condition = new _Condition(new RandomString(), expression);

        Assert.Same(expression, condition.Expression);
    }

    [Fact]
    public void InitializeParametersFromCollection()
    {
        IEnumerable<IConditionParameter> parameters =
        [
            new ConditionParameter(
                new RandomString(),
                new ConditionParameterType(new RandomString())
            ),
        ];

        ICondition condition = new _Condition(
            new RandomString(),
            new RandomString(),
            parameters
        );

        Assert.Same(parameters, condition.Parameters);
    }

    [Fact]
    public void InitializeParametersFromArguments()
    {
        IConditionParameter grantTime = new ConditionParameter(
            new RandomString(),
            new ConditionParameterType(new RandomString())
        );
        IConditionParameter duration = new ConditionParameter(
            new RandomString(),
            new ConditionParameterType(new RandomString())
        );

        ICondition condition = new _Condition(
            new RandomString(),
            new RandomString(),
            grantTime,
            duration
        );

        Assert.Collection(
            condition.Parameters,
            parameter => Assert.Same(grantTime, parameter),
            parameter => Assert.Same(duration, parameter)
        );
    }

    [Fact]
    public void InitializeWithoutParameters()
    {
        ICondition condition = new _Condition(new RandomString(), new RandomString());

        Assert.Empty(condition.Parameters);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Condition(new RandomString(), new RandomString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Condition(new RandomString(), new RandomString()).ToString()
        );
    }
}
