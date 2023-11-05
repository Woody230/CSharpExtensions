﻿using System.Collections;
using System.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

public abstract class ExtensibleCollection<T, TCollection> : IExtensibleCollection<T, TCollection> where TCollection : ExtensibleCollection<T, TCollection>
{
    private readonly ICollection<T> _collection;

    public ExtensibleCollection(ICollection<T> collection)
    {
        _collection = collection;
    }

    public virtual TCollection Add(T item)
    {
        _collection.Add(item);
        return (TCollection)this;
    }

    public TCollection Remove(T item)
    {
        TryRemove(item);
        return (TCollection)this;
    }

    public TCollection CopyTo(T[] array, int arrayIndex)
    {
        _collection.CopyTo(array, arrayIndex);
        return (TCollection)this;
    }


    #region Delegated
    public int Count => _collection.Count;

    public bool IsReadOnly => _collection.IsReadOnly;

    void ICollection<T>.Add(T item)
    {
        Add(item);
    }

    public void Clear()
    {
        _collection.Clear();
    }

    public bool Contains(T item)
    {
        return _collection.Contains(item);
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        _collection.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _collection.GetEnumerator();
    }

    public virtual bool TryRemove(T item)
    {
        return _collection.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _collection.GetEnumerator();
    }

    bool ICollection<T>.Remove(T item) => TryRemove(item);

    #endregion Delegated
}