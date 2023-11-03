using System.Collections.Generic;

namespace Woody230.Collections.Generic;

public class ExtensibleSet<T>: ExtensibleCollection<T>, IExtensibleSet<T>
{
    private readonly ISet<T> _set;

    public ExtensibleSet(ISet<T> set): base(set)
    {
        _set = set;
    }

    public ExtensibleSet(): this(new HashSet<T>())
    {
    }

    /// <summary>
    /// Adds each item in the <paramref name="other"/> collection to <paramref name="this"/> collection.
    /// </summary>
    public static ExtensibleSet<T> operator +(ExtensibleSet<T> @this, IEnumerable<T> other) => @this.AddAll(other);

    /// <summary>
    /// Removes each item in the <paramref name="other"/> collection from <paramref name="this"/> collection.
    /// </summary>
    public static ExtensibleSet<T> operator -(ExtensibleSet<T> @this, IEnumerable<T> other) => @this.RemoveAll(other);

    #region Delegation
    bool ISet<T>.Add(T item)
    {
        return _set.Add(item);
    }

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

    #endregion Delegation
}
