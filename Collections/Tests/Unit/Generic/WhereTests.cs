using FluentAssertions;
using Woody230.Collections.Generic;
using Xunit;

namespace Woody230.Collections.Tests.Unit.Generic;
public class WhereTests
{
    [Fact]
    public void Where()
    {
        // Arrange 
        var list = new List<int>() { 1, 3, 4, 9, 12, 15, 44, 99, 100 };

        // Act
        var not = list.Where(item => item % 3 == 0);

        // Assert
        not.Should().BeEquivalentTo(new List<int> { 3, 9, 12, 15, 99 });
    }

    [Fact]
    public void WhereNot()
    {
        // Arrange 
        var list = new List<int>() { 1, 3, 4, 9, 12, 15, 44, 99, 100 };

        // Act
        var not = list.WhereNot(item => item % 3 == 0);

        // Assert
        not.Should().BeEquivalentTo(new List<int> { 1, 4, 44, 100 });
    }

    [Fact]
    public void WhereNull()
    {
        // Arrange
        var list = new List<int?> { 1, 3, 4, null, 9, 12, 15, null, 44, 99, 100 };

        // Act
        var @null = list.WhereNull();

        // Assert
        @null.Should().BeEquivalentTo(new List<int?> { null, null });
    }

    [Fact]
    public void WhereNotNull()
    {
        // Arrange
        var list = new List<int?> { 1, 3, 4, null, 9, 12, 15, null, 44, 99, 100 };

        // Act
        var notNull = list.WhereNotNull();

        // Assert
        notNull.Should().BeEquivalentTo(new List<int?> { 1, 3, 4, 9, 12, 15, 44, 99, 100 });
    }

    [Fact]
    public void WhereDefault_NullDefault()
    {
        // Arrange
        var list = new List<int?> { 0, 1, 3, 4, null, 9, 12, 15, null, 44, 99, 100 };

        // Act
        var @default = list.WhereDefault();

        // Assert
        @default.Should().BeEquivalentTo(new List<int?> { null, null });
    }

    [Fact]
    public void WhereNotDefault_NullDefault()
    {
        // Arrange
        var list = new List<int?> { 0, 1, 3, 4, null, 9, 12, 15, null, 44, 99, 100 };

        // Act
        var notDefault = list.WhereNotDefault();

        // Assert
        notDefault.Should().BeEquivalentTo(new List<int?> { 0, 1, 3, 4, 9, 12, 15, 44, 99, 100 });
    }

    [Fact]
    public void WhereDefault_NotNullDefault()
    {
        // Arrange
        var list = new List<int> { 0, 1, 3, 4, 0, 9, 12, 15, 0, 44, 99, 100 };

        // Act
        var @default = list.WhereDefault();

        // Assert
        @default.Should().BeEquivalentTo(new List<int> { 0, 0, 0 });
    }

    [Fact]
    public void WhereNotDefault_NotNullDefault()
    {
        // Arrange
        var list = new List<int> { 0, 1, 3, 4, 0, 9, 12, 15, 0, 44, 99, 100 };

        // Act
        var notDefault = list.WhereNotDefault();

        // Assert
        notDefault.Should().BeEquivalentTo(new List<int> { 1, 3, 4, 9, 12, 15, 44, 99, 100 });
    }

    [Fact]
    public void WhereInstanceOf()
    {
        // Arrange
        var list = new List<object>()
        {
            1,
            Array.Empty<string>(),
            "Foo",
            new List<string>() { "Fizz", "Buzz" },
            1.23M,
            new List<int>() { 4, 9 },
            new List<string>() { "Bar" }
        };

        // Act
        var instanceOf = list.WhereInstanceOf<IEnumerable<string>>();

        // Assert
        instanceOf.Should().BeEquivalentTo(new List<IEnumerable<string>>()
        {
            Array.Empty<string>(),
            new List<string>() { "Fizz", "Buzz" },
            new List<string>() { "Bar" }
        });
    }
}
