using FluentAssertions;
using System;
using Woody230.BindableEnum.Models;
using Xunit;

namespace Woody230.BindableEnum.Tests.Unit
{
    /// <summary>
    /// Represents implicit operator conversion tests for <see cref="BindableEnum{T}"/>
    /// </summary>
    public class ImplicitConversionTests
    {
        /// <summary>
        /// Verifies that enums can be converted to and back from a bindable enum implicitly.
        /// </summary>
        [Fact]
        public void Conversions_AreSuccessful()
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
    }
}
