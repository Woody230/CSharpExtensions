namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="ISet{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleSet<T> : IExtensibleCollection<T>, ISet<T>
{
    /// <summary>
    /// Creates a new instance of the collection.
    /// </summary>
    public new IExtensibleSet<T> ShallowCopy();

    IExtensibleCollection<T> IExtensibleCollection<T>.ShallowCopy() => ShallowCopy();

    #region Operators
    public static IExtensibleSet<T> operator +(IExtensibleSet<T> @this, IEnumerable<T> other) => @this.Plus(other);
    public static IExtensibleSet<T> operator -(IExtensibleSet<T> @this, IEnumerable<T> other) => @this.Minus(other);
    public static IExtensibleSet<T> operator +(IExtensibleSet<T> @this, T item) => @this.Plus(item);
    public static IExtensibleSet<T> operator -(IExtensibleSet<T> @this, T item) => @this.Minus(item);
    #endregion Operators
}