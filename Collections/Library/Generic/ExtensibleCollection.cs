using System.Collections;
using System.Collections.Generic;

namespace Woody230.Collections.Generic;

public abstract class ExtensibleCollection<T>: IExtensibleCollection<T>
{
    private readonly ICollection<T> _collection;

    public ExtensibleCollection(ICollection<T> collection)
    {
        _collection = collection;
    }

    public IExtensibleCollection<T> Add(T item)
    {
        _collection.Add(item);
        return this;
    }

    /// <summary>
    /// Adds each item in the <paramref name="other"/> collection to <paramref name="this"/> collection.
    /// </summary>
    public static ExtensibleCollection<T> operator +(ExtensibleCollection<T> @this, IEnumerable<T> other) => @this.AddAll(other);

    /// <summary>
    /// Removes each item in the <paramref name="other"/> collection from <paramref name="this"/> collection.
    /// </summary>
    public static ExtensibleCollection<T> operator -(ExtensibleCollection<T> @this, IEnumerable<T> other) => @this.RemoveAll(other);

    public IExtensibleCollection<T> CopyTo(T[] array, int arrayIndex)
    {
        _collection.CopyTo(array, arrayIndex);
        return this;
    }

    #region Delegated
    public int Count => _collection.Count;

    public bool IsReadOnly => _collection.IsReadOnly;

    void ICollection<T>.Add(T item)
    {
        _collection.Add(item);
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

    public bool Remove(T item)
    {
        return _collection.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _collection.GetEnumerator();
    }

    #endregion Delegated
}
