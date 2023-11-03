using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic.Set;

/// <summary>
/// Represents a <see cref="ISet{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleSet<T> : IExtensibleCollection<T>, ISet<T>
{
    /// <summary>
    /// Adds each item in the <paramref name="other"/> collection to <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleSet<T> operator +(IExtensibleSet<T> @this, IEnumerable<T> other) => @this.AddAll(other);

    /// <summary>
    /// Removes each item in the <paramref name="other"/> collection from <paramref name="this"/> collection.
    /// </summary>
    public static IExtensibleSet<T> operator -(IExtensibleSet<T> @this, IEnumerable<T> other) => @this.RemoveAll(other);
}
