using Pure.Authorization.OpenFGA.Model.Abstractions.Model;
using Pure.Authorization.OpenFGA.Model.Abstractions.Rewrite;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Model;

/// <summary>
/// A relation of a type definition. DSL: <c>define viewer: [user] or editor</c>.
/// </summary>
public sealed record RelationDefinition : IRelationDefinition
{
    public RelationDefinition(IString name, IRewrite rewrite)
    {
        Name = name;
        Rewrite = rewrite;
    }

    public IString Name { get; }

    public IRewrite Rewrite { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
