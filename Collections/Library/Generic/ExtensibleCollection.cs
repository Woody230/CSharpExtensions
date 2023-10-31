using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Woody230.Collections.Generic;

public abstract class ExtensibleCollection<T>: IExtensibleCollection<T>
{
    private readonly List<T> _list = new();

    public IExtensibleCollection<T> AddRange(IEnumerable<T> collection)
    {
        _list.AddRange(collection);
        return this;
    }

    public IExtensibleCollection<T> ForEach(Action<T> action)
    {
        _list.ForEach(action);
        return this;
    }

    public IExtensibleCollection<T> Add(T item)
    {
        _list.Add(item);
        return this;
    }

    public IExtensibleCollection<T> CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
        return this;
    }

    public bool ContainsAll(IEnumerable<T> collection)
    {
        return collection.All(item => Contains(item));
    }

    #region Delegated
    public int Count => _list.Count;

    public bool IsReadOnly => ((ICollection<T>)_list).IsReadOnly;

    void ICollection<T>.Add(T item)
    {
        _list.Add(item);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public bool Contains(T item)
    {
        return _list.Contains(item);
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    public bool Remove(T item)
    {
        return _list.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    #endregion Delegated
}
