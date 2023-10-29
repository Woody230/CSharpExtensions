using System.Collections;
using System.Collections.Generic;

namespace Woody230.AspNetCore.App.Modules;
public class WebApplicationBuilderModuleCollection: IWebApplicationBuilderModuleCollection
{
    private readonly List<IWebApplicationBuilderModule> _list = new();

    #region Delegation
    public int Count => ((ICollection<IWebApplicationBuilderModule>)_list).Count;

    public bool IsReadOnly => ((ICollection<IWebApplicationBuilderModule>)_list).IsReadOnly;

    public void Add(IWebApplicationBuilderModule item)
    {
        ((ICollection<IWebApplicationBuilderModule>)_list).Add(item);
    }

    public void Clear()
    {
        ((ICollection<IWebApplicationBuilderModule>)_list).Clear();
    }

    public bool Contains(IWebApplicationBuilderModule item)
    {
        return ((ICollection<IWebApplicationBuilderModule>)_list).Contains(item);
    }

    public void CopyTo(IWebApplicationBuilderModule[] array, int arrayIndex)
    {
        ((ICollection<IWebApplicationBuilderModule>)_list).CopyTo(array, arrayIndex);
    }

    public IEnumerator<IWebApplicationBuilderModule> GetEnumerator()
    {
        return ((IEnumerable<IWebApplicationBuilderModule>)_list).GetEnumerator();
    }

    public bool Remove(IWebApplicationBuilderModule item)
    {
        return ((ICollection<IWebApplicationBuilderModule>)_list).Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_list).GetEnumerator();
    }
    #endregion Delegation
}
