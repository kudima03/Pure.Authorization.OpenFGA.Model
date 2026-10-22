using Pure.Authorization.OpenFGA.Model.Abstractions.Model;
using Pure.Primitives.Abstractions.String;

namespace Pure.Authorization.OpenFGA.Model.Model;

/// <summary>
/// An object type and the relations defined on it. DSL: <c>type document</c>.
/// </summary>
public sealed record TypeDefinition : ITypeDefinition
{
    public TypeDefinition(IString name, params IEnumerable<IRelationDefinition> relations)
    {
        Name = name;
        Relations = relations;
    }

    public IString Name { get; }

    public IEnumerable<IRelationDefinition> Relations { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
