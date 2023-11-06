using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Woody230.Text.StringBuilder;

/// <summary>
/// Represents a <see cref="System.Text.StringBuilder"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="TBuilder">The type of the builder that is extending from this builder.</typeparam>
public abstract class ExtensibleStringBuilder<TBuilder> : IExtensibleStringBuilder<TBuilder> where TBuilder: ExtensibleStringBuilder<TBuilder>
{
    /// <summary>
    /// The string builder.
    /// </summary>
    private readonly System.Text.StringBuilder _builder;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtendedStringBuilder"/> class.
    /// </summary>
    /// <param name="builder">The string builder.</param>
    public ExtensibleStringBuilder(System.Text.StringBuilder builder)
    {
        _builder = builder;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtendedStringBuilder"/> class with a new string builder.
    /// </summary>
    public ExtensibleStringBuilder() : this(new())
    {
    }

    #region IExtensibleStringBuilder Delegated
    public int Capacity
    {
        get => _builder.Capacity;
        set => _builder.Capacity = value;
    }
    public int Length
    {
        get => _builder.Length;
        set => _builder.Length = value;
    }
    public int MaxCapacity => _builder.MaxCapacity;
    public char this[int index]
    {
        get => _builder[index];
        set => _builder[index] = value;
    }

    public int EnsureCapacity(int capacity) => _builder.EnsureCapacity(capacity);
    public override string ToString() => _builder.ToString();
    public string ToString(int startIndex, int length) => _builder.ToString(startIndex, length);
    public TBuilder Clear()
    {
        _builder.Clear();
        return (TBuilder)this;
    }

    public System.Text.StringBuilder.ChunkEnumerator GetChunks() => _builder.GetChunks();

    public TBuilder Append(char value, int repeatCount)
    {
        _builder.Append(value, repeatCount);
        return (TBuilder)this;
    }

    public TBuilder Append(char[]? value, int startIndex, int charCount)
    {
        _builder.Append(value, startIndex, charCount);
        return (TBuilder)this;
    }

    public TBuilder Append(string? value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(string? value, int startIndex, int count)
    {
        _builder.Append(value, startIndex, count);
        return (TBuilder)this;
    }

    public TBuilder Append(System.Text.StringBuilder? value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(System.Text.StringBuilder? value, int startIndex, int count)
    {
        _builder.Append(value, startIndex, count);
        return (TBuilder)this;
    }

    public TBuilder AppendLine()
    {
        _builder.AppendLine();
        return (TBuilder)this;
    }

    public TBuilder AppendLine(string? value)
    {
        _builder.AppendLine(value);
        return (TBuilder)this;
    }

    public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
    {
        _builder.CopyTo(sourceIndex, destination, destinationIndex, count);
    }

    public void CopyTo(int sourceIndex, Span<char> destination, int count)
    {
        _builder.CopyTo(sourceIndex, destination, count);
    }

    public TBuilder Insert(int index, string? value, int count)
    {
        _builder.Insert(index, value, count);
        return (TBuilder)this;
    }

    public TBuilder Remove(int startIndex, int length)
    {
        _builder.Remove(startIndex, length);
        return (TBuilder)this;
    }

    public TBuilder Append(bool value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(char value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(sbyte value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(byte value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(short value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(int value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(long value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(float value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(double value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(decimal value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(ushort value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(uint value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(ulong value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(object? value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(char[]? value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(ReadOnlySpan<char> value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append(ReadOnlyMemory<char> value)
    {
        _builder.Append(value);
        return (TBuilder)this;
    }

    public TBuilder Append([InterpolatedStringHandlerArgument("")] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
    {
        _builder.Append(ref handler);
        return (TBuilder)this;
    }

    public TBuilder Append(IFormatProvider? provider, [InterpolatedStringHandlerArgument(new[] { "", "provider" })] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
    {
        _builder.Append(provider, ref handler);
        return (TBuilder)this;
    }

    public TBuilder AppendLine([InterpolatedStringHandlerArgument("")] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
    {
        _builder.AppendLine(ref handler);
        return (TBuilder)this;
    }

    public TBuilder AppendLine(IFormatProvider? provider, [InterpolatedStringHandlerArgument(new[] { "", "provider" })] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
    {
        _builder.Append(provider, ref handler);
        return (TBuilder)this;
    }

    public TBuilder AppendJoin(string? separator, params object?[] values)
    {
        _builder.AppendJoin(separator, values);
        return (TBuilder)this;
    }

    public TBuilder AppendJoin<T>(string? separator, IEnumerable<T> values)
    {
        _builder.AppendJoin(separator, values);
        return (TBuilder)this;
    }

    public TBuilder AppendJoin(string? separator, params string?[] values)
    {
        _builder.AppendJoin(separator, values);
        return (TBuilder)this;
    }

    public TBuilder AppendJoin(char separator, params object?[] values)
    {
        _builder.AppendJoin(separator, values);
        return (TBuilder)this;
    }

    public TBuilder AppendJoin<T>(char separator, IEnumerable<T> values)
    {
        _builder.AppendJoin(separator, values);
        return (TBuilder)this;
    }

    public TBuilder AppendJoin(char separator, params string?[] values)
    {
        _builder.AppendJoin(separator, values);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, string? value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, bool value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, sbyte value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, byte value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, short value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, char value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, char[]? value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, char[]? value, int startIndex, int charCount)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, int value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, long value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, float value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, double value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, decimal value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, ushort value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, uint value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, ulong value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, object? value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder Insert(int index, ReadOnlySpan<char> value)
    {
        _builder.Insert(index, value);
        return (TBuilder)this;
    }

    public TBuilder AppendFormat(string format, object? arg0)
    {
        _builder.AppendFormat(format, arg0);
        return (TBuilder)this;
    }

    public TBuilder AppendFormat(string format, object? arg0, object? arg1)
    {
        _builder.AppendFormat(format, arg0, arg1);
        return (TBuilder)this;
    }

    public TBuilder AppendFormat(string format, object? arg0, object? arg1, object? arg2)
    {
        _builder.AppendFormat(format, arg0, arg1, arg2);
        return (TBuilder)this;
    }

    public TBuilder AppendFormat(string format, params object?[] args)
    {
        _builder.AppendFormat(format, args);
        return (TBuilder)this;
    }

    public TBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0)
    {
        _builder.AppendFormat(provider, format, arg0);
        return (TBuilder)this;
    }

    public TBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1)
    {
        _builder.AppendFormat(provider, format, arg0, arg1);
        return (TBuilder)this;
    }

    public TBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1, object? arg2)
    {
        _builder.AppendFormat(provider, format, arg0, arg1, arg2);
        return (TBuilder)this;
    }

    public TBuilder AppendFormat(IFormatProvider? provider, string format, params object?[] args)
    {
        _builder.AppendFormat(provider, format, args);
        return (TBuilder)this;
    }

    public TBuilder Replace(string oldValue, string? newValue)
    {
        _builder.Replace(oldValue, newValue);
        return (TBuilder)this;
    }

    public bool Equals([NotNullWhen(true)] System.Text.StringBuilder? sb)
    {
        return _builder.Equals(sb);
    }

    public bool Equals(ReadOnlySpan<char> span)
    {
        return _builder.Equals(span);
    }

    public TBuilder Replace(string oldValue, string? newValue, int startIndex, int count)
    {
        _builder.Replace(oldValue, newValue, startIndex, count);
        return (TBuilder)this;
    }

    public TBuilder Replace(char oldChar, char newChar)
    {
        _builder.Replace(oldChar, newChar);
        return (TBuilder)this;
    }

    public TBuilder Replace(char oldChar, char newChar, int startIndex, int count)
    {
        _builder.Replace(oldChar, newChar, startIndex, count);
        return (TBuilder)this;
    }

    public override bool Equals(object? obj)
    {
        return _builder.Equals(obj);
    }

    public override int GetHashCode()
    {
        return _builder.GetHashCode();
    }

    #endregion IExtensibleStringBuilder Delegated

    #region IExtensibleStringBuilder Implementation
    public TBuilder Prepend(string value)
    {
        return Insert(0, value);
    }

    #endregion IExtensibleStringBuilder Implementation
}
