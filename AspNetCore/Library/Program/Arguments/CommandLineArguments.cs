using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Woody230.AspNetCore.Program.Arguments;

/// <inheritdoc/>
public sealed class CommandLineArguments: ICommandLineArguments
{
    private readonly List<string> _list = new();

    public CommandLineArguments(string[] arguments)
    {
        _list = arguments.ToList();
    }

    public CommandLineArguments(IEnumerable<string> arguments)
    {
        _list = arguments.ToList();
    }

    #region Delegation
    public int Count => ((ICollection<string>)_list).Count;

    public bool IsReadOnly => ((ICollection<string>)_list).IsReadOnly;

    public void Add(string item)
    {
        ((ICollection<string>)_list).Add(item);
    }

    public void Clear()
    {
        ((ICollection<string>)_list).Clear();
    }

    public bool Contains(string item)
    {
        return ((ICollection<string>)_list).Contains(item);
    }

    public void CopyTo(string[] array, int arrayIndex)
    {
        ((ICollection<string>)_list).CopyTo(array, arrayIndex);
    }

    public IEnumerator<string> GetEnumerator()
    {
        return ((IEnumerable<string>)_list).GetEnumerator();
    }

    public bool Remove(string item)
    {
        return ((ICollection<string>)_list).Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_list).GetEnumerator();
    }

    #endregion Delegation
}
