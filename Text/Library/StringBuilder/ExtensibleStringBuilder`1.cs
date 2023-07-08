using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Woody230.Text.StringBuilder
{
    /// <summary>
    /// Represents a <see cref="System.Text.StringBuilder"/> that is extensible with additional functionality.
    /// </summary>
    /// <typeparam name="TBuilder">The type of the builder that is extending from this builder.</typeparam>
    public abstract class ExtensibleStringBuilder<TBuilder>: ExtensibleStringBuilder where TBuilder: ExtensibleStringBuilder<TBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensibleStringBuilder"/> class.
        /// </summary>
        /// <param name="builder">The string builder.</param>
        public ExtensibleStringBuilder(System.Text.StringBuilder builder): base(builder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensibleStringBuilder"/> class with a new string builder.
        /// </summary>
        public ExtensibleStringBuilder(): base()
        {
        }

        #region TBuilder Delegated
        
        public new TBuilder Clear()
        {
            base.Clear();
            return (TBuilder)this;
        }

        public new TBuilder Append(char value, int repeatCount)
        {
            base.Append(value, repeatCount);
            return (TBuilder)this;
        }

        public new TBuilder Append(char[]? value, int startIndex, int charCount)
        {
            base.Append(value, startIndex, charCount); 
            return (TBuilder)this;
        }

        public new TBuilder Append(string? value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(string? value, int startIndex, int count)
        {
            base.Append(value, startIndex, count);
            return (TBuilder)this;
        }

        public new TBuilder Append(System.Text.StringBuilder? value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(System.Text.StringBuilder? value, int startIndex, int count)
        {
            base.Append(value, startIndex, count);
            return (TBuilder)this;
        }

        public new TBuilder AppendLine()
        {
            base.AppendLine();
            return (TBuilder)this;
        }

        public new TBuilder AppendLine(string? value)
        {
            base.AppendLine(value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, string? value, int count)
        {
            base.Insert(index, value, count);
            return (TBuilder)this;
        }

        public new TBuilder Remove(int startIndex, int length)
        {
            base.Remove(startIndex, length);
            return (TBuilder)this;
        }

        public new TBuilder Append(bool value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(char value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(sbyte value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(byte value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(short value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(int value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(long value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(float value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(double value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(decimal value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(ushort value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(uint value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(ulong value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(object? value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(char[]? value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(ReadOnlySpan<char> value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append(ReadOnlyMemory<char> value)
        {
            base.Append(value);
            return (TBuilder)this;
        }

        public new TBuilder Append([InterpolatedStringHandlerArgument("")] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
        {
            base.Append(ref handler);
            return (TBuilder)this;
        }

        public new TBuilder Append(IFormatProvider? provider, [InterpolatedStringHandlerArgument(new[] { "", "provider" })] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
        {
            base.Append(provider, ref handler); 
            return (TBuilder)this;
        }

        public new TBuilder AppendLine([InterpolatedStringHandlerArgument("")] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
        {
            base.AppendLine(ref handler);
            return (TBuilder)this;
        }

        public new TBuilder AppendLine(IFormatProvider? provider, [InterpolatedStringHandlerArgument(new[] { "", "provider" })] ref System.Text.StringBuilder.AppendInterpolatedStringHandler handler)
        {
            base.Append(provider, ref handler);
            return (TBuilder)this;
        }

        public new TBuilder AppendJoin(string? separator, params object?[] values)
        {
            base.AppendJoin(separator, values);
            return (TBuilder)this;
        }

        public new TBuilder AppendJoin<T>(string? separator, IEnumerable<T> values)
        {
            base.AppendJoin(separator, values);
            return (TBuilder)this;
        }

        public new TBuilder AppendJoin(string? separator, params string?[] values)
        {
            base.AppendJoin(separator, values);
            return (TBuilder)this;
        }

        public new TBuilder AppendJoin(char separator, params object?[] values)
        {
            base.AppendJoin(separator, values);
            return (TBuilder)this;
        }

        public new TBuilder AppendJoin<T>(char separator, IEnumerable<T> values)
        {
            base.AppendJoin(separator, values);
            return (TBuilder)this;
        }

        public new TBuilder AppendJoin(char separator, params string?[] values)
        {
            base.AppendJoin(separator, values);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, string? value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, bool value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, sbyte value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, byte value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, short value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, char value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, char[]? value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, char[]? value, int startIndex, int charCount)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, int value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, long value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, float value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, double value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, decimal value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, ushort value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, uint value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, ulong value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, object? value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder Insert(int index, ReadOnlySpan<char> value)
        {
            base.Insert(index, value);
            return (TBuilder)this;
        }

        public new TBuilder AppendFormat(string format, object? arg0)
        {
            base.AppendFormat(format, arg0);
            return (TBuilder)this;
        }

        public new TBuilder AppendFormat(string format, object? arg0, object? arg1)
        {
            base.AppendFormat(format, arg0, arg1);
            return (TBuilder)this;
        }

        public new TBuilder AppendFormat(string format, object? arg0, object? arg1, object? arg2)
        {
            base.AppendFormat(format, arg0, arg1, arg2);
            return (TBuilder)this;
        }

        public new TBuilder AppendFormat(string format, params object?[] args)
        {
            base.AppendFormat(format, args);
            return (TBuilder)this;
        }

        public new TBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0)
        {
            base.AppendFormat(provider, format, arg0);
            return (TBuilder)this;
        }

        public new TBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1)
        {
            base.AppendFormat(provider, format, arg0, arg1); 
            return (TBuilder)this;
        }

        public new TBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1, object? arg2)
        {
            base.AppendFormat(provider, format, arg0, arg1, arg2);
            return (TBuilder)this;
        }

        public new TBuilder AppendFormat(IFormatProvider? provider, string format, params object?[] args)
        {
            base.AppendFormat(provider, format, args);
            return (TBuilder)this;
        }

        public new TBuilder Replace(string oldValue, string? newValue)
        {
            base.Replace(oldValue, newValue);
            return (TBuilder)this;
        }

        public new TBuilder Replace(string oldValue, string? newValue, int startIndex, int count)
        {
            base.Replace(oldValue, newValue, startIndex, count);
            return (TBuilder)this;
        }

        public new TBuilder Replace(char oldChar, char newChar)
        {
            base.Replace(oldChar, newChar);
            return (TBuilder)this;
        }

        public new TBuilder Replace(char oldChar, char newChar, int startIndex, int count)
        {
            base.Replace(oldChar, newChar, startIndex, count);
            return (TBuilder)this;
        }

        #endregion TBuilder Delegated

        #region TBuilder Implementation
        public new TBuilder Prepend(string value)
        {
            base.Prepend(value);
            return (TBuilder)this;
        }

        #endregion TBuilder Implementation
    }
}
