using System.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="IList{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleList<T> : IExtensibleCollection<T>, IList<T>
{

}

/// <summary>
/// Represents a <see cref="IList{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
/// /// <typeparam name="TCollection">The type of the implementation of the interface.</typeparam>
public interface IExtensibleList<T, TCollection> : IExtensibleCollection<T, TCollection>, IExtensibleList<T> where TCollection : IExtensibleList<T, TCollection>
{
}
