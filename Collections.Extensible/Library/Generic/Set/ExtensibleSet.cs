namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="ISet{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public abstract class ExtensibleSet<T> : ExtensibleCollection<T>, IExtensibleSet<T>
{
    private readonly ISet<T> _set;

    public ExtensibleSet(ISet<T> set) : base(set)
    {
        _set = set;
    }

    public override abstract IExtensibleSet<T> ShallowCopy();

    public virtual new bool Add(T item)
    {
        return _set.Add(item);
    }

    #region Delegated

    public virtual void ExceptWith(IEnumerable<T> other)
    {
        _set.ExceptWith(other);
    }

    public virtual void IntersectWith(IEnumerable<T> other)
    {
        _set.IntersectWith(other);
    }

    public virtual bool IsProperSubsetOf(IEnumerable<T> other)
    {
        return _set.IsProperSubsetOf(other);
    }

    public virtual bool IsProperSupersetOf(IEnumerable<T> other)
    {
        return _set.IsProperSupersetOf(other);
    }

    public virtual bool IsSubsetOf(IEnumerable<T> other)
    {
        return _set.IsSubsetOf(other);
    }

    public virtual bool IsSupersetOf(IEnumerable<T> other)
    {
        return _set.IsSupersetOf(other);
    }

    public virtual bool Overlaps(IEnumerable<T> other)
    {
        return _set.Overlaps(other);
    }

    public virtual bool SetEquals(IEnumerable<T> other)
    {
        return _set.SetEquals(other);
    }

    public virtual void SymmetricExceptWith(IEnumerable<T> other)
    {
        _set.SymmetricExceptWith(other);
    }

    public virtual void UnionWith(IEnumerable<T> other)
    {
        _set.UnionWith(other);
    }

    bool ISet<T>.Add(T item) => Add(item);

    #endregion Delegated
}
