using FluentAssertions;
using Woody230.BindableEnum.Models;
using Xunit;

namespace Woody230.BindableEnum.Tests.Unit;

/// <summary>
/// Represents bindable extensions tests for <see cref="IBindableEnum{T}"/>.
/// </summary>
public class BindableTests
{
    /// <summary>
    /// Verifies that an enum can be explicitly converted to a bindable.
    /// </summary>
    [Fact]
    public void Bindable()
    {
        DayOfWeek @enum = DayOfWeek.Monday;
        var bindable = @enum.Bindable();
        bindable.Should().NotBeNull();
        bindable.Enum.Should().Be(DayOfWeek.Monday);
    }

    /// <summary>
    /// Verifies that a null enum can be explicitly converted to a bindable.
    /// </summary>
    [Fact]
    public void NullBindable()
    {
        DayOfWeek? nullableEnum = null;
        var bindable = nullableEnum.Bindable();
        bindable.Should().BeNull();

        nullableEnum = DayOfWeek.Monday;
        bindable = nullableEnum.Bindable();
        bindable.Should().NotBeNull();
        bindable.Enum.Should().Be(DayOfWeek.Monday);
    }
}
