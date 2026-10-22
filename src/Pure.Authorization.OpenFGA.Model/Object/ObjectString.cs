using System.Collections;
using Pure.Authorization.OpenFGA.Model.Abstractions.Object;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.String.Operations;

namespace Pure.Authorization.OpenFGA.Model.Object;

/// <summary>
/// The OpenFGA text form of an object: <c>type:id</c>, e.g. <c>document:1</c>.
/// The parts are written as they are, without validation or escaping.
/// </summary>
public sealed record ObjectString : IString
{
    private readonly IObject _object;

    public ObjectString(IObject @object)
    {
        _object = @object;
    }

    public string TextValue => Text.TextValue;

    private IString Text => new ColonJoinedString(_object.Type, _object.Id);

    public IEnumerator<IChar> GetEnumerator()
    {
        return Text.GetEnumerator();
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
