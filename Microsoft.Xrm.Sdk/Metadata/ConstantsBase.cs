using System.Collections.Generic;

namespace Microsoft.Xrm.Sdk.Metadata;

public abstract class ConstantsBase<T>
{
    protected static readonly IList<T> ValidValues = new List<T>();
    private T _value;
    public T Value
    {
        get { return _value; }
        set
        {
            _value = value;
        }
    }
    protected static T2 Add<T2>(T value) where T2 : ConstantsBase<T>, new()
    {
        ValidValues.Add(value);
        return Create<T2>(value);
    }
    protected static T2 Create<T2>(T value) where T2 : ConstantsBase<T>, new()
    {
        return new T2 { _value = value };
    }
    protected abstract bool ValueExistsInList(T value);
}