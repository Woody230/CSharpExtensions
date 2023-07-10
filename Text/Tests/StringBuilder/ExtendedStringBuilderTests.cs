using FluentAssertions;
using Woody230.Text.StringBuilder;
using Xunit;

namespace Woody230.Text.Tests.StringBuilder;

/// <summary>
/// Represents tests for the <see cref="ExtendedStringBuilder"/> class.
/// </summary>
public class ExtendedStringBuilderTests
{
    /// <summary>
    /// Verifies that a string can be created from a new string builder.
    /// </summary>
    [Fact]
    public void BuildsString()
    {
        // Arrange
        var builder = new ExtendedStringBuilder();

        // Act
        var str = builder.Append("a").Append("bc").Prepend("def").Insert(4, "g").Prepend("i").AppendLine("jk").Append("l").AppendFormat("{0} {1}", 1, " - ").ToString();

        // Assert
        str.Should().Be("idefagbcjk\r\nl1  - ");
    }

    /// <summary>
    /// Verifies that a string can be created using an existing string builder.
    /// </summary>
    [Fact] 
    public void WithStringBuilder_BuildsString()
    {
        // Arrange
        var builder = new ExtendedStringBuilder(new System.Text.StringBuilder("foo bar baz"));

        // Act
        var str = builder.Append("a").Append("bc").Prepend("def").Insert(4, "g").Prepend("i").AppendLine("jk").Append("l").AppendFormat("{0} {1}", 1, " - ").ToString();

        // Assert
        str.Should().Be("ideffgoo bar bazabcjk\r\nl1  - ");
    }
}
