using System.Collections;

namespace Woody230.Collections.Extensible.Generic;

public abstract class ExtensibleCollection<T> : IExtensibleCollection<T>
{
    private readonly ICollection<T> _collection;

    public ExtensibleCollection(ICollection<T> collection)
    {
        _collection = collection;
    }
    public abstract IExtensibleCollection<T> ShallowCopy();

    #region Delegated
    public virtual int Count => _collection.Count;

    public virtual bool IsReadOnly => _collection.IsReadOnly;

    public virtual void Clear()
    {
        _collection.Clear();
    }

    public virtual bool Contains(T item)
    {
        return _collection.Contains(item);
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex) => CopyTo(array, arrayIndex);

    public virtual IEnumerator<T> GetEnumerator()
    {
        return _collection.GetEnumerator();
    }

    public virtual bool TryRemove(T item)
    {
        return _collection.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public virtual void Add(T item)
    {
        _collection.Add(item);
    }

    public virtual bool Remove(T item)
    {
        return _collection.Remove(item);
    }

    public virtual void CopyTo(T[] array, int arrayIndex)
    {
        _collection.CopyTo(array, arrayIndex);
    }

    #endregion Delegated
}
