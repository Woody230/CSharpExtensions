using System.Collections.Generic;

namespace Woody230.Collections.Generic;

public abstract class ExtensibleList<T> : ExtensibleCollection<T>, IExtensibleList<T>
{
    private readonly List<T> _list;

    public ExtensibleList(IList<T> list): base(list)
    {
    }

    public T this[int index] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public int IndexOf(T item)
    {
        throw new System.NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new System.NotImplementedException();
    }
}
