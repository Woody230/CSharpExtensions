using System.Collections;

namespace Woody230.AspNetCore.Application.Modules.Collection;
public class WebApplicationModuleCollection : IWebApplicationModuleCollection
{
    private readonly List<IWebApplicationModule> _list = new();

    #region Delegation
    public int Count => ((ICollection<IWebApplicationModule>)_list).Count;

    public bool IsReadOnly => ((ICollection<IWebApplicationModule>)_list).IsReadOnly;

    public void Add(IWebApplicationModule item)
    {
        ((ICollection<IWebApplicationModule>)_list).Add(item);
    }

    public void Clear()
    {
        ((ICollection<IWebApplicationModule>)_list).Clear();
    }

    public bool Contains(IWebApplicationModule item)
    {
        return ((ICollection<IWebApplicationModule>)_list).Contains(item);
    }

    public void CopyTo(IWebApplicationModule[] array, int arrayIndex)
    {
        ((ICollection<IWebApplicationModule>)_list).CopyTo(array, arrayIndex);
    }

    public IEnumerator<IWebApplicationModule> GetEnumerator()
    {
        return ((IEnumerable<IWebApplicationModule>)_list).GetEnumerator();
    }

    public bool Remove(IWebApplicationModule item)
    {
        return ((ICollection<IWebApplicationModule>)_list).Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_list).GetEnumerator();
    }
    #endregion Delegation
}
