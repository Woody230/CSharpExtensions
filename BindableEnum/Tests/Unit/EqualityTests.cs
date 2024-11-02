using Woody230.BindableEnum.Models;

namespace Woody230.BindableEnum.Tests.Unit;

/// <summary>
/// Represents equality tests for the <see cref="BindableEnum{T}"/> class.
/// </summary>
public class EqualityTests
{
    /// <summary>
    /// Verifies equality between different bindable enums.
    /// </summary>
    [Fact]
    public void IsEqual()
    {
        // Arrange
        BindableEnum<DayOfWeek> first = DayOfWeek.Monday;
        BindableEnum<DayOfWeek> second = new("Monday");
        BindableEnum<DayOfWeek> third = new(DayOfWeek.Monday);

        // Act / Assert
        first.Equals(second).Should().BeTrue();
        first.Equals(third).Should().BeTrue();
    }

    /// <summary>
    /// Verifies equality between different bindable enums.
    /// </summary>
    [Fact]
    public void IsNotEqual()
    {
        // Arrange
        BindableEnum<DayOfWeek> first = DayOfWeek.Monday;
        BindableEnum<DayOfWeek> second = new("Tuesday");
        BindableEnum<DayOfWeek> third = new(DayOfWeek.Tuesday);

        // Act / Assert
        first.Equals(second).Should().BeFalse();
        first.Equals(third).Should().BeFalse();
    }

    /// <summary>
    /// Verifies the hash code between different bindable enums.
    /// </summary>
    [Fact]
    public void IsEqualHash()
    {
        // Arrange
        BindableEnum<DayOfWeek> first = DayOfWeek.Monday;
        BindableEnum<DayOfWeek> second = new("Monday");
        BindableEnum<DayOfWeek> third = new(DayOfWeek.Monday);

        // Act / Assert
        first.GetHashCode().Should().Be(second.GetHashCode());
        first.GetHashCode().Should().Be(third.GetHashCode());
    }

    /// <summary>
    /// Verifies the hash code between different bindable enums.
    /// </summary>
    [Fact]
    public void IsNotEqualHash()
    {
        // Arrange
        BindableEnum<DayOfWeek> first = DayOfWeek.Monday;
        BindableEnum<DayOfWeek> second = new("Tuesday");
        BindableEnum<DayOfWeek> third = new(DayOfWeek.Tuesday);

        // Act / Assert
        first.GetHashCode().Should().NotBe(second.GetHashCode());
        first.GetHashCode().Should().NotBe(third.GetHashCode());
    }

    /// <summary>
    /// Verifies the equality of checking against a null enum.
    /// </summary>
    [Fact]
    public void Null_NotEqual()
    {
        // Arrange
        BindableEnum<DayOfWeek> @enum = null;

        // Act / Assert
        (@enum == DayOfWeek.Thursday).Should().BeFalse();
        (@enum == DayOfWeek.Sunday).Should().BeTrue(because: "default enum");
    }
}
