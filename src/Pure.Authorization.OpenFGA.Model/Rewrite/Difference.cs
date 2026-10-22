using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;

namespace Pure.Authorization.OpenFGA.Model.Rewrite;

/// <summary>
/// Holders of the base who do not hold the subtracted part. DSL: <c>a but not b</c>.
/// </summary>
public sealed record Difference : IDifference
{
    public Difference(IRewrite @base, IRewrite subtract)
    {
        Base = @base;
        Subtract = subtract;
    }

    public IRewrite Base { get; }

    public IRewrite Subtract { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
