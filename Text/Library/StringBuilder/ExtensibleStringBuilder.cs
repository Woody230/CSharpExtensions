using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Woody230.Text.StringBuilder
{
    public class ExtensibleStringBuilder: IExtensibleStringBuilder
    {
        /// <summary>
        /// The string builder.
        /// </summary>
        private readonly System.Text.StringBuilder _builder;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensibleStringBuilder"/> class.
        /// </summary>
        /// <param name="builder">The string builder.</param>
        public ExtensibleStringBuilder(System.Text.StringBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensibleStringBuilder"/> class with a new string builder.
        /// </summary>
        public ExtensibleStringBuilder(): this(new())
        {
        }

        public int EnsureCapacity(int capacity) => _builder.EnsureCapacity(capacity);
        public override string ToString() => _builder.ToString();
        public string ToString(int startIndex, int length) => _builder.ToString(startIndex, length);
        public IExtensibleStringBuilder Clear()
        {
            _builder.Clear();
            return this;
        }

        public System.Text.StringBuilder.ChunkEnumerator GetChunks() => _builder.GetChunks();

        public IExtensibleStringBuilder Append(char value, int repeatCount)
        {
            _builder.Append(value, repeatCount);
            return this;
        }

        public IExtensibleStringBuilder Append(char[]? value, int startIndex, int charCount)
        {
            _builder.Append(value, startIndex, charCount); 
            return this;
        }

        public IExtensibleStringBuilder Append(string? value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(string? value, int startIndex, int count)
        {
            _builder.Append(value, startIndex, count);
            return this;
        }

        public IExtensibleStringBuilder Append(System.Text.StringBuilder? value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(System.Text.StringBuilder? value, int startIndex, int count)
        {
            _builder.Append(value, startIndex, count);
            return this;
        }

        public IExtensibleStringBuilder AppendLine()
        {
            _builder.AppendLine();
            return this;
        }

        public IExtensibleStringBuilder AppendLine(string? value)
        {
            _builder.AppendLine(value);
            return this;
        }

        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            _builder.CopyTo(sourceIndex, destination, destinationIndex, count);
        }

        public void CopyTo(int sourceIndex, Span<char> destination, int count)
        {
            _builder.CopyTo(sourceIndex, destination, count);
        }

        public IExtensibleStringBuilder Insert(int index, string? value, int count)
        {
            _builder.Insert(index, value, count);
            return this;
        }

        public IExtensibleStringBuilder Remove(int startIndex, int length)
        {
            _builder.Remove(startIndex, length);
            return this;
        }

        public IExtensibleStringBuilder Append(bool value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(char value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(sbyte value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(byte value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(short value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(int value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(long value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(float value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(double value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(decimal value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(ushort value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(uint value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(ulong value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(object? value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(char[]? value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(ReadOnlySpan<char> value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append(ReadOnlyMemory<char> value)
        {
            _builder.Append(value);
            return this;
        }

        public IExtensibleStringBuilder Append([InterpolatedStringHandlerArgument("")] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
        {
            _builder.Append(ref handler);
            return this;
        }

        public IExtensibleStringBuilder Append(IFormatProvider? provider, [InterpolatedStringHandlerArgument(new[] { "", "provider" })] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
        {
            _builder.Append(provider, ref handler); 
            return this;
        }

        public IExtensibleStringBuilder AppendLine([InterpolatedStringHandlerArgument("")] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
        {
            _builder.AppendLine(ref handler);
            return this;
        }

        public IExtensibleStringBuilder AppendLine(IFormatProvider? provider, [InterpolatedStringHandlerArgument(new[] { "", "provider" })] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
        {
            _builder.Append(provider, ref handler);
            return this;
        }

        public IExtensibleStringBuilder AppendJoin(string? separator, params object?[] values)
        {
            _builder.AppendJoin(separator, values);
            return this;
        }

        public IExtensibleStringBuilder AppendJoin<T>(string? separator, IEnumerable<T> values)
        {
            _builder.AppendJoin(separator, values);
            return this;
        }

        public IExtensibleStringBuilder AppendJoin(string? separator, params string?[] values)
        {
            _builder.AppendJoin(separator, values);
            return this;
        }

        public IExtensibleStringBuilder AppendJoin(char separator, params object?[] values)
        {
            _builder.AppendJoin(separator, values);
            return this;
        }

        public IExtensibleStringBuilder AppendJoin<T>(char separator, IEnumerable<T> values)
        {
            _builder.AppendJoin(separator, values);
            return this;
        }

        public IExtensibleStringBuilder AppendJoin(char separator, params string?[] values)
        {
            _builder.AppendJoin(separator, values);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, string? value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, bool value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, sbyte value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, byte value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, short value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, char value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, char[]? value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, char[]? value, int startIndex, int charCount)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, int value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, long value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, float value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, double value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, decimal value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, ushort value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, uint value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, ulong value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, object? value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder Insert(int index, ReadOnlySpan<char> value)
        {
            _builder.Insert(index, value);
            return this;
        }

        public IExtensibleStringBuilder AppendFormat(string format, object? arg0)
        {
            _builder.AppendFormat(format, arg0);
            return this;
        }

        public IExtensibleStringBuilder AppendFormat(string format, object? arg0, object? arg1)
        {
            _builder.AppendFormat(format, arg0, arg1);
            return this;
        }

        public IExtensibleStringBuilder AppendFormat(string format, object? arg0, object? arg1, object? arg2)
        {
            _builder.AppendFormat(format, arg0, arg1, arg2);
            return this;
        }

        public IExtensibleStringBuilder AppendFormat(string format, params object?[] args)
        {
            _builder.AppendFormat(format, args);
            return this;
        }

        public IExtensibleStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0)
        {
            _builder.AppendFormat(provider, format, arg0);
            return this;
        }

        public IExtensibleStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1)
        {
            _builder.AppendFormat(provider, format, arg0, arg1); 
            return this;
        }

        public IExtensibleStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1, object? arg2)
        {
            _builder.AppendFormat(provider, format, arg0, arg1, arg2);
            return this;
        }

        public IExtensibleStringBuilder AppendFormat(IFormatProvider? provider, string format, params object?[] args)
        {
            _builder.AppendFormat(provider, format, args);
            return this;
        }

        public IExtensibleStringBuilder Replace(string oldValue, string? newValue)
        {
            _builder.Replace(oldValue, newValue);
            return this;
        }

        public bool Equals([NotNullWhen(true)] System.Text.StringBuilder? sb)
        {
            return _builder.Equals(sb);
        }

        public bool Equals(ReadOnlySpan<char> span)
        {
            return _builder.Equals(span);
        }

        public IExtensibleStringBuilder Replace(string oldValue, string? newValue, int startIndex, int count)
        {
            _builder.Replace(oldValue, newValue, startIndex, count);
            return this;
        }

        public IExtensibleStringBuilder Replace(char oldChar, char newChar)
        {
            _builder.Replace(oldChar, newChar);
            return this;
        }

        public IExtensibleStringBuilder Replace(char oldChar, char newChar, int startIndex, int count)
        {
            _builder.Replace(oldChar, newChar, startIndex, count);
            return this;
        }
    }
}
