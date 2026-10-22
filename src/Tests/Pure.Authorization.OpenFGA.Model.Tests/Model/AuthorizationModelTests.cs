using Pure.Authorization.OpenFGA.Model.Abstractions.Condition;
using Pure.Authorization.OpenFGA.Model.Abstractions.Model;
using Pure.Authorization.OpenFGA.Model.Model;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using _Condition = Pure.Authorization.OpenFGA.Model.Condition.Condition;

namespace Pure.Authorization.OpenFGA.Model.Tests.Model;

public sealed record AuthorizationModelTests
{
    [Fact]
    public void InitializeSchemaVersion()
    {
        IString schemaVersion = new RandomString();

        IAuthorizationModel model = new AuthorizationModel(schemaVersion, [], []);

        Assert.Same(schemaVersion, model.SchemaVersion);
    }

    [Fact]
    public void InitializeTypes()
    {
        IEnumerable<ITypeDefinition> types =
        [
            new TypeDefinition(new RandomString()),
            new TypeDefinition(new RandomString()),
        ];

        IAuthorizationModel model = new AuthorizationModel(new RandomString(), types, []);

        Assert.Same(types, model.Types);
    }

    [Fact]
    public void InitializeConditions()
    {
        IEnumerable<ICondition> conditions =
        [
            new _Condition(new RandomString(), new RandomString()),
            new _Condition(new RandomString(), new RandomString()),
        ];

        IAuthorizationModel model = new AuthorizationModel(
            new RandomString(),
            [],
            conditions
        );

        Assert.Same(conditions, model.Conditions);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new AuthorizationModel(new RandomString(), [], []).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new AuthorizationModel(new RandomString(), [], []).ToString()
        );
    }
}
