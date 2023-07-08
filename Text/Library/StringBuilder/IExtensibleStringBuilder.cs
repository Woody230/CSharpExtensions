using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Text.StringBuilder;

namespace Woody230.Text.StringBuilder
{
    /// <summary>
    /// Represents a <see cref="System.Text.StringBuilder"/> that is extensible with additional functionality.
    /// </summary>
    public interface IExtensibleStringBuilder<TBuilder> where TBuilder: IExtensibleStringBuilder<TBuilder>
    {
        #region base
        public TBuilder Clear();
        public TBuilder Append(char value, int repeatCount);
        public TBuilder Append(char[]? value, int startIndex, int charCount);
        public TBuilder Append(string? value);
        public TBuilder Append(string? value, int startIndex, int count);
        public TBuilder Append(System.Text.StringBuilder? value);
        public TBuilder Append(System.Text.StringBuilder? value, int startIndex, int count);
        public TBuilder AppendLine();
        public TBuilder AppendLine(string? value);
        public TBuilder Insert(int index, string? value, int count);
        public TBuilder Remove(int startIndex, int length);
        public TBuilder Append(bool value);
        public TBuilder Append(char value);
        public TBuilder Append(sbyte value);
        public TBuilder Append(byte value);
        public TBuilder Append(short value);
        public TBuilder Append(int value);
        public TBuilder Append(long value);
        public TBuilder Append(float value);
        public TBuilder Append(double value);
        public TBuilder Append(decimal value);
        public TBuilder Append(ushort value);
        public TBuilder Append(uint value);
        public TBuilder Append(ulong value);
        public TBuilder Append(object? value);
        public TBuilder Append(char[]? value);
        public TBuilder Append(ReadOnlySpan<char> value);
        public TBuilder Append(ReadOnlyMemory<char> value);
        public TBuilder Append([InterpolatedStringHandlerArgument("")] ref AppendInterpolatedStringHandler handler);
        public TBuilder Append(IFormatProvider? provider, [InterpolatedStringHandlerArgument("", "provider")] ref AppendInterpolatedStringHandler handler);
        public TBuilder AppendLine([InterpolatedStringHandlerArgument("")] ref AppendInterpolatedStringHandler handler);
        public TBuilder AppendLine(IFormatProvider? provider, [InterpolatedStringHandlerArgument("", "provider")] ref AppendInterpolatedStringHandler handler);
        public TBuilder AppendJoin(string? separator, params object?[] values);
        public TBuilder AppendJoin<T>(string? separator, IEnumerable<T> values);
        public TBuilder AppendJoin(string? separator, params string?[] values);
        public TBuilder AppendJoin(char separator, params object?[] values);
        public TBuilder AppendJoin<T>(char separator, IEnumerable<T> values);
        public TBuilder AppendJoin(char separator, params string?[] values);
        public TBuilder Insert(int index, string? value);
        public TBuilder Insert(int index, bool value);
        public TBuilder Insert(int index, sbyte value);
        public TBuilder Insert(int index, byte value);
        public TBuilder Insert(int index, short value);
        public TBuilder Insert(int index, char value);
        public TBuilder Insert(int index, char[]? value);
        public TBuilder Insert(int index, char[]? value, int startIndex, int charCount);
        public TBuilder Insert(int index, int value);
        public TBuilder Insert(int index, long value);
        public TBuilder Insert(int index, float value);
        public TBuilder Insert(int index, double value);
        public TBuilder Insert(int index, decimal value);
        public TBuilder Insert(int index, ushort value);
        public TBuilder Insert(int index, uint value);
        public TBuilder Insert(int index, ulong value);
        public TBuilder Insert(int index, object? value);
        public TBuilder Insert(int index, ReadOnlySpan<char> value);
        public TBuilder AppendFormat(string format, object? arg0);
        public TBuilder AppendFormat(string format, object? arg0, object? arg1);
        public TBuilder AppendFormat(string format, object? arg0, object? arg1, object? arg2);
        public TBuilder AppendFormat(string format, params object?[] args);
        public TBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0);
        public TBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1);
        public TBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1, object? arg2);
        public TBuilder AppendFormat(IFormatProvider? provider, string format, params object?[] args);
        public TBuilder Replace(string oldValue, string? newValue);
        public TBuilder Replace(string oldValue, string? newValue, int startIndex, int count);
        public TBuilder Replace(char oldChar, char newChar);
        public TBuilder Replace(char oldChar, char newChar, int startIndex, int count);
        #endregion base

        #region extensible
        /// <summary>
        /// Adds the value to the beginning of the string being built.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>This builder.</returns>
        public TBuilder Prepend(string value);
        #endregion extensible
    }
}
