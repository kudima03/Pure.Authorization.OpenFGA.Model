using Pure.Authorization.OpenFGA.Model.Abstractions.Condition;
using Pure.Authorization.OpenFGA.Model.Condition;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;

namespace Pure.Authorization.OpenFGA.Model.Tests.Condition;

public sealed record ConditionParameterTypeTests
{
    [Fact]
    public void InitializeName()
    {
        IString name = new RandomString();

        IConditionParameterType type = new ConditionParameterType(name);

        Assert.Same(name, type.Name);
    }

    [Fact]
    public void InitializeGenericTypesFromCollection()
    {
        IEnumerable<IConditionParameterType> genericTypes =
        [
            new ConditionParameterType(new RandomString()),
        ];

        IConditionParameterType type = new ConditionParameterType(
            new RandomString(),
            genericTypes
        );

        Assert.Same(genericTypes, type.GenericTypes);
    }

    [Fact]
    public void InitializeGenericTypesFromArguments()
    {
        IConditionParameterType element = new ConditionParameterType(new RandomString());

        IConditionParameterType type = new ConditionParameterType(
            new RandomString(),
            element
        );

        IConditionParameterType single = Assert.Single(type.GenericTypes);
        Assert.Same(element, single);
    }

    [Fact]
    public void InitializeNestedGenericTypes()
    {
        IConditionParameterType inner = new ConditionParameterType(new RandomString());
        IConditionParameterType list = new ConditionParameterType(
            new RandomString(),
            inner
        );

        IConditionParameterType map = new ConditionParameterType(
            new RandomString(),
            list
        );

        Assert.Same(inner, Assert.Single(Assert.Single(map.GenericTypes).GenericTypes));
    }

    [Fact]
    public void InitializeWithoutGenericTypes()
    {
        IConditionParameterType type = new ConditionParameterType(new RandomString());

        Assert.Empty(type.GenericTypes);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ConditionParameterType(new RandomString()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new ConditionParameterType(new RandomString()).ToString()
        );
    }
}
