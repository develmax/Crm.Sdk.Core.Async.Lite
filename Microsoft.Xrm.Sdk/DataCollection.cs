using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Microsoft.Xrm.Sdk;

public class DataCollection<T> : Collection<T>
{
    public void AddRange(params T[] items)
    {
        foreach (var item in items)
        {
            this.Add(item);
        }
    }
    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            this.Add(item);
        }
    }
    public T[] ToArray()
    {
        return this.ToArray<T>();
    }
}
public abstract class DataCollection<TKey, TValue> : Dictionary<TKey, TValue>
{
    public virtual bool IsReadOnly { get; set; }
    public new void Add(TKey key, TValue value)
    {
        if (IsReadOnly)
            return;
        base.Add(key, value);
    }
    public void Add(KeyValuePair<TKey, TValue> item)
    {
        if (IsReadOnly)
            return;
        this.Add(item.Key, item.Value);
    }
    public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
    {
        if (IsReadOnly)
            return;
        this.AddRange(items.ToArray());
    }
    public void AddRange(params KeyValuePair<TKey, TValue>[] items)
    {
        if (IsReadOnly)
            return;
        foreach (var item in items)
        {
            this.Add(item);
        }
    }
    public bool Contains(TKey key)
    {
        return base.ContainsKey(key);
    }
    public bool Contains(KeyValuePair<TKey, TValue> key)
    {
        return base.ContainsKey(key.Key) && base.ContainsValue(key.Value);
    }
}