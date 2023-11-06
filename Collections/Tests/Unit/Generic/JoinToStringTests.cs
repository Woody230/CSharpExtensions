using FluentAssertions;
using Woody230.Collections.Generic;
using Xunit;

namespace Woody230.Collections.Tests.Unit.Generic;
public class JoinToStringTests
{
    [Fact]
    public void JoinToString()
    {
        // Arrange
        var list = new List<int>() { 1, 5, 99 };

        // Act
        var stringified = list.JoinToString("@#$", item => (item + .25).ToString());

        // Assert
        stringified.Should().BeEquivalentTo("1.25@#$5.25@#$99.25");
    }

    [Fact]
    public void JoinToString_SeparatorDefault()
    {
        // Arrange
        var list = new List<int>() { 1, 5, 99 };

        // Act
        var stringified = list.JoinToString(item => (item + .25).ToString());

        // Assert
        stringified.Should().BeEquivalentTo("1.25, 5.25, 99.25");
    }

    [Fact]
    public void JoinToString_ToStringDefault()
    {
        // Arrange
        var list = new List<int>() { 1, 5, 99 };

        // Act
        var stringified = list.JoinToString("@#$");

        // Assert
        stringified.Should().BeEquivalentTo("1@#$5@#$99");
    }

    [Fact]
    public void JoinToString_Default()
    {
        // Arrange
        var list = new List<int>() { 1, 5, 99 };

        // Act
        var stringified = list.JoinToString();

        // Assert
        stringified.Should().BeEquivalentTo("1, 5, 99");
    }
}
