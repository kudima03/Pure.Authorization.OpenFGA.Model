using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;

namespace Pure.Authorization.OpenFGA.Model.Rewrite;

/// <summary>
/// Holders of all of the children. DSL: <c>a and b</c>.
/// </summary>
public sealed record Intersection : IIntersection
{
    public Intersection(params IEnumerable<IRewrite> children)
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
