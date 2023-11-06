using FluentAssertions;
using Woody230.BindableEnum.Models;
using Xunit;

namespace Woody230.BindableEnum.Tests.Unit;

/// <summary>
/// Represents implicit operator conversion tests for <see cref="BindableEnum{T}"/>.
/// </summary>
public class ImplicitConversionTests
{
    /// <summary>
    /// Verifies that an enum can be implicitly converted to and back from a bindable enum implicitly.
    /// </summary>
    [Fact]
    public void ConvertToAndFromEnum()
    {
        BindableEnum<DayOfWeek> bindable = DayOfWeek.Monday;
        bindable.Enum.Should().Be(DayOfWeek.Monday);

        DayOfWeek @enum = bindable;
        @enum.Should().Be(DayOfWeek.Monday);

        DayOfWeek? nullableEnum = bindable;
        nullableEnum.Should().Be(DayOfWeek.Monday);

        bindable = nullableEnum;
        bindable.Should().NotBeNull();
        bindable.Enum.Should().Be(DayOfWeek.Monday);
    }

    /// <summary>
    /// Verifies that a null enum can be implicitly converted to and back from a bindable enum implicitly.
    /// </summary>
    [Fact]
    public void ConvertToAndFromNullEnum()
    {
        DayOfWeek? nullableEnum = null;
        BindableEnum<DayOfWeek> bindable = nullableEnum;
        bindable.Should().BeNull();

        nullableEnum = bindable;
        nullableEnum.Should().BeNull();
    }

    /// <summary>
    /// Verifies that a string can be implicitly converted to and back from a bindable enum implicitly.
    /// </summary>
    [Fact]
    public void ConvertToAndFromString()
    {
        string @string = "Tuesday";
        BindableEnum<DayOfWeek> bindable = @string;
        bindable.Should().NotBeNull();
        bindable.Binded.Should().BeTrue();
        bindable.Enum.Should().Be(DayOfWeek.Tuesday);

        @string = bindable;
        @string.Should().Be("Tuesday");
    }

    /// <summary>
    /// Verifies that a nullable string can be implicitly converted to and back from a bindable enum implicitly.
    /// </summary>
    [Fact]
    public void ConvertToAndFromNullableString()
    {
        string @string = null;
        BindableEnum<DayOfWeek> bindable = @string;
        bindable.Should().BeNull();

        @string = bindable;
        @string.Should().BeNull();
    }
}
