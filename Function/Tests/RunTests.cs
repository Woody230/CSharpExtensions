namespace Woody230.Function.Tests;

/// <summary>
/// Represents tests for the run methods within the <see cref="ScopeFunctionExtensions"/>.
/// </summary>
public class RunTests
{
    private readonly TestObject _object = new()
    {
        Int = 43595121,
        Bool = true,
        String = "FooBarBaz"
    };

    private readonly TestObject _blockObject = new()
    {
        Int = 832134,
        String = "qwerty"
    };

    [Fact]
    public void Run_WithObject_WithReturn_ReturnsFunctionObject()
    {
        // Arrange
        int Block(TestObject @object) => _blockObject.Int + @object.Int;

        // Act
        var result = _object.Run(Block);

        // Assert
        result.Should().Be(44427255);
    }
}
