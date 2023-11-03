using System.Collections.Generic;

namespace Woody230.Collections.Generic;

public abstract class ExtensibleList<T> : ExtensibleCollection<T>, IExtensibleList<T>
{
    private readonly IList<T> _list;

    public ExtensibleList(IList<T> list): base(list)
    {
        _list = list;
    }

    public ExtensibleList(): this(new List<T>())
    {
    }

    /// <summary>
    /// Adds each item in the <paramref name="other"/> collection to <paramref name="this"/> collection.
    /// </summary>
    public static ExtensibleList<T> operator +(ExtensibleList<T> @this, IEnumerable<T> other) => @this.AddAll(other);

    /// <summary>
    /// Removes each item in the <paramref name="other"/> collection from <paramref name="this"/> collection.
    /// </summary>
    public static ExtensibleList<T> operator -(ExtensibleList<T> @this, IEnumerable<T> other) => @this.RemoveAll(other);


    #region Delegation
    public T this[int index] { get => _list[index]; set => _list[index] = value; }

    public int IndexOf(T item) => _list.IndexOf(item);

    public void Insert(int index, T item) => _list.Insert(index, item);

    public void RemoveAt(int index) => _list.RemoveAt(index);
    #endregion Delegation
}
