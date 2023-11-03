using System.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="ISet{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
/// <typeparam name="TCollection">The type of the implementation of the interface.</typeparam>
public abstract class ExtensibleSet<T, TCollection> : ExtensibleCollection<T, TCollection>, IExtensibleSet<T, TCollection> where TCollection: ExtensibleSet<T, TCollection>
{
    private readonly ISet<T> _set;

    public ExtensibleSet(ISet<T> set) : base(set)
    {
        _set = set;
    }

    public ExtensibleSet() : this(new HashSet<T>())
    {
    }

    TCollection IExtensibleSet<T, TCollection>.Add(T item)
    {
        _set.Add(item);
        return (TCollection) this;
    }

    public bool TryAdd(T item)
    {
        return _set.Add(item);
    }


    #region Delegated

    public void ExceptWith(IEnumerable<T> other)
    {
        _set.ExceptWith(other);
    }

    public void IntersectWith(IEnumerable<T> other)
    {
        _set.IntersectWith(other);
    }

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        return _set.IsProperSubsetOf(other);
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        return _set.IsProperSupersetOf(other);
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        return _set.IsSubsetOf(other);
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        return _set.IsSupersetOf(other);
    }

    public bool Overlaps(IEnumerable<T> other)
    {
        return _set.Overlaps(other);
    }

    public bool SetEquals(IEnumerable<T> other)
    {
        return _set.SetEquals(other);
    }

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        _set.SymmetricExceptWith(other);
    }

    public void UnionWith(IEnumerable<T> other)
    {
        _set.UnionWith(other);
    }

    #endregion Delegated
}
