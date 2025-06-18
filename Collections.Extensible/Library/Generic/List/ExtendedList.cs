namespace Woody230.Collections.Extensible.Generic;

/// <inheritdoc/>
public sealed class ExtendedList<T>(IList<T> list) : ExtensibleList<T>(list)
{
    public ExtendedList(IEnumerable<T> collection): this(collection.ToList())
    {
    }

    public ExtendedList(): this([])
    {
    }

    public override ExtendedList<T> ShallowCopy()
    {
        var list = new List<T>(this);
        return [.. list];
    }

    #region Operators
    public static ExtendedList<T> operator +(ExtendedList<T> @this, IEnumerable<T> other) => @this.Plus(other);
    public static ExtendedList<T> operator -(ExtendedList<T> @this, IEnumerable<T> other) => @this.Minus(other);
    public static ExtendedList<T> operator +(ExtendedList<T> @this, T item) => @this.Plus(item);
    public static ExtendedList<T> operator -(ExtendedList<T> @this, T item) => @this.Minus(item);
    #endregion Operators
}
