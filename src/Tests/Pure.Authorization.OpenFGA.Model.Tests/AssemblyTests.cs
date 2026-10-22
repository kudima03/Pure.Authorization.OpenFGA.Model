using System.Reflection;

namespace Pure.Authorization.OpenFGA.Model.Tests;

public sealed record AssemblyTests
{
    [Fact]
    public void MarkedAsTrimmable()
    {
        Assembly assembly = Assembly.Load("Pure.Authorization.OpenFGA.Model");

        Assert.Contains(
            assembly.GetCustomAttributes<AssemblyMetadataAttribute>(),
            attribute => attribute is { Key: "IsTrimmable", Value: "True" }
        );
    }
}
