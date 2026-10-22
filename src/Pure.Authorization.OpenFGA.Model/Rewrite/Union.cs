using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;

namespace Pure.Authorization.OpenFGA.Model.Rewrite;

/// <summary>
/// Holders of any of the children. DSL: <c>a or b</c>.
/// </summary>
public sealed record Union : IUnion
{
    public Union(params IEnumerable<IRewrite> children)
    {
        Children = children;
    }

    public IEnumerable<IRewrite> Children { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
