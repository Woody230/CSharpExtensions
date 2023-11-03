using System.Collections.Generic;

namespace Woody230.Collections.Generic;

/// <summary>
/// Represents a <see cref="ISet{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleSet<T>: IExtensibleCollection<T>, ISet<T>
{
}
