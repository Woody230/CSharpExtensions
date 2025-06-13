namespace Woody230.Function.Tests;

/// <summary>
/// Represents tests for the apply methods within the <see cref="ScopeFunctionExtensions"/>.
/// </summary>
public class ApplyTests
{
    private readonly TestObject _object = new()
    {
        Int = 914819,
        String = "FizzBuzz"
    };

    private readonly TestObject _actionObject = new()
    {
        Int = 5,
        Bool = true,
        String = "test"
    };

    [Fact]
    public void Apply_NoReturn_ReturnsObject()
    {
        // Arrange
        void Action() => _actionObject.Int += 1;

        // Act
        var result = _object.Apply(Action);

        // Assert
        result.Should().Be(_object);

        _actionObject.Should().BeEquivalentTo(new TestObject()
        {
            Int = 6,
            Bool = true,
            String = "test"
        });
    }

    [Fact]
    public void Apply_WithObject_ReturnsObject()
    {
        // Arrange
        void Action(TestObject @object) => _actionObject.Int += @object.Int;

        // Act
        var result = _object.Apply(Action);

        // Assert
        result.Should().Be(_object);

        _actionObject.Should().BeEquivalentTo(new TestObject()
        {
            Int = 914824,
            Bool = true,
            String = "test"
        });
    }

    [Fact]
    public void Apply_WithReturn_ReturnsObject()
    {
        // Arrange
        int Action() => _actionObject.Int += 1;

        // Act
        var result = _object.Apply(Action);

        // Assert
        result.Should().Be(_object);

        _actionObject.Should().BeEquivalentTo(new TestObject()
        {
            Int = 6,
            Bool = true,
            String = "test"
        });
    }

    [Fact]
    public void Apply_WithObject_WithReturn_ReturnsObject()
    {
        // Arrange
        int Action(TestObject @object) => _actionObject.Int += @object.Int;

        // Act
        var result = _object.Apply(Action);

        // Assert
        result.Should().Be(_object);

        _actionObject.Should().BeEquivalentTo(new TestObject()
        {
            Int = 914824,
            Bool = true,
            String = "test"
        });
    }
}
