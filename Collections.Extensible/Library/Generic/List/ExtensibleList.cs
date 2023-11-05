using System.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="IList{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public abstract class ExtensibleList<T> : ExtensibleCollection<T>, IExtensibleList<T>
{
    private readonly IList<T> _list;

    public ExtensibleList(IList<T> list) : base(list)
    {
        _list = list;
    }

    #region Delegated
    public virtual T this[int index] { get => _list[index]; set => _list[index] = value; }

    public virtual int IndexOf(T item) => _list.IndexOf(item);

    public virtual void Insert(int index, T item) => _list.Insert(index, item);

    public virtual void RemoveAt(int index) => _list.RemoveAt(index);
    #endregion Delegated
}
