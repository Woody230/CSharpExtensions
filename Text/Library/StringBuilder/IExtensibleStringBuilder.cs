using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Text.StringBuilder;

namespace Woody230.Text.StringBuilder
{
    /// <summary>
    /// Represents a <see cref="System.Text.StringBuilder"/> that is extensible with additional functionality.
    /// </summary>
    public interface IExtensibleStringBuilder
    {
        #region base
        public IExtensibleStringBuilder Clear();
        public IExtensibleStringBuilder Append(char value, int repeatCount);
        public IExtensibleStringBuilder Append(char[]? value, int startIndex, int charCount);
        public IExtensibleStringBuilder Append(string? value);
        public IExtensibleStringBuilder Append(string? value, int startIndex, int count);
        public IExtensibleStringBuilder Append(System.Text.StringBuilder? value);
        public IExtensibleStringBuilder Append(System.Text.StringBuilder? value, int startIndex, int count);
        public IExtensibleStringBuilder AppendLine();
        public IExtensibleStringBuilder AppendLine(string? value);
        public IExtensibleStringBuilder Insert(int index, string? value, int count);
        public IExtensibleStringBuilder Remove(int startIndex, int length);
        public IExtensibleStringBuilder Append(bool value);
        public IExtensibleStringBuilder Append(char value);
        public IExtensibleStringBuilder Append(sbyte value);
        public IExtensibleStringBuilder Append(byte value);
        public IExtensibleStringBuilder Append(short value);
        public IExtensibleStringBuilder Append(int value);
        public IExtensibleStringBuilder Append(long value);
        public IExtensibleStringBuilder Append(float value);
        public IExtensibleStringBuilder Append(double value);
        public IExtensibleStringBuilder Append(decimal value);
        public IExtensibleStringBuilder Append(ushort value);
        public IExtensibleStringBuilder Append(uint value);
        public IExtensibleStringBuilder Append(ulong value);
        public IExtensibleStringBuilder Append(object? value);
        public IExtensibleStringBuilder Append(char[]? value);
        public IExtensibleStringBuilder Append(ReadOnlySpan<char> value);
        public IExtensibleStringBuilder Append(ReadOnlyMemory<char> value);
        public IExtensibleStringBuilder Append([InterpolatedStringHandlerArgument("")] ref AppendInterpolatedStringHandler handler);
        public IExtensibleStringBuilder Append(IFormatProvider? provider, [InterpolatedStringHandlerArgument("", "provider")] ref AppendInterpolatedStringHandler handler);
        public IExtensibleStringBuilder AppendLine([InterpolatedStringHandlerArgument("")] ref AppendInterpolatedStringHandler handler);
        public IExtensibleStringBuilder AppendLine(IFormatProvider? provider, [InterpolatedStringHandlerArgument("", "provider")] ref AppendInterpolatedStringHandler handler);
        public IExtensibleStringBuilder AppendJoin(string? separator, params object?[] values);
        public IExtensibleStringBuilder AppendJoin<T>(string? separator, IEnumerable<T> values);
        public IExtensibleStringBuilder AppendJoin(string? separator, params string?[] values);
        public IExtensibleStringBuilder AppendJoin(char separator, params object?[] values);
        public IExtensibleStringBuilder AppendJoin<T>(char separator, IEnumerable<T> values);
        public IExtensibleStringBuilder AppendJoin(char separator, params string?[] values);
        public IExtensibleStringBuilder Insert(int index, string? value);
        public IExtensibleStringBuilder Insert(int index, bool value);
        public IExtensibleStringBuilder Insert(int index, sbyte value);
        public IExtensibleStringBuilder Insert(int index, byte value);
        public IExtensibleStringBuilder Insert(int index, short value);
        public IExtensibleStringBuilder Insert(int index, char value);
        public IExtensibleStringBuilder Insert(int index, char[]? value);
        public IExtensibleStringBuilder Insert(int index, char[]? value, int startIndex, int charCount);
        public IExtensibleStringBuilder Insert(int index, int value);
        public IExtensibleStringBuilder Insert(int index, long value);
        public IExtensibleStringBuilder Insert(int index, float value);
        public IExtensibleStringBuilder Insert(int index, double value);
        public IExtensibleStringBuilder Insert(int index, decimal value);
        public IExtensibleStringBuilder Insert(int index, ushort value);
        public IExtensibleStringBuilder Insert(int index, uint value);
        public IExtensibleStringBuilder Insert(int index, ulong value);
        public IExtensibleStringBuilder Insert(int index, object? value);
        public IExtensibleStringBuilder Insert(int index, ReadOnlySpan<char> value);
        public IExtensibleStringBuilder AppendFormat(string format, object? arg0);
        public IExtensibleStringBuilder AppendFormat(string format, object? arg0, object? arg1);
        public IExtensibleStringBuilder AppendFormat(string format, object? arg0, object? arg1, object? arg2);
        public IExtensibleStringBuilder AppendFormat(string format, params object?[] args);
        public IExtensibleStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0);
        public IExtensibleStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1);
        public IExtensibleStringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1, object? arg2);
        public IExtensibleStringBuilder AppendFormat(IFormatProvider? provider, string format, params object?[] args);
        public IExtensibleStringBuilder Replace(string oldValue, string? newValue);
        public IExtensibleStringBuilder Replace(string oldValue, string? newValue, int startIndex, int count);
        public IExtensibleStringBuilder Replace(char oldChar, char newChar);
        public IExtensibleStringBuilder Replace(char oldChar, char newChar, int startIndex, int count);
        #endregion base

        #region extensible
        /// <summary>
        /// Adds the value to the beginning of the string being built.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>This builder.</returns>
        public IExtensibleStringBuilder Prepend(string value);
        #endregion extensible
    }
}
