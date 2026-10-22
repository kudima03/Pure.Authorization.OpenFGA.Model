using Pure.Authorization.OpenFGA.Model.Abstractions.Condition;
using Pure.Authorization.OpenFGA.Model.Condition;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Condition;

public sealed record ConditionParameterTests
{
    [Fact]
    public void InitializeName()
    {
        IString name = new RandomString();

        IConditionParameter parameter = new ConditionParameter(
            name,
            new ConditionParameterType(new RandomString())
        );

        Assert.Same(name, parameter.Name);
    }

    [Fact]
    public void InitializeType()
    {
        IConditionParameterType type = new ConditionParameterType(new RandomString());

        IConditionParameter parameter = new ConditionParameter(new RandomString(), type);

        Assert.Same(type, parameter.Type);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ConditionParameter(
                new RandomString(),
                new ConditionParameterType(new RandomString())
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ConditionParameter(
                new RandomString(),
                new ConditionParameterType(new RandomString())
            ).ToString()
        );
    }
}
