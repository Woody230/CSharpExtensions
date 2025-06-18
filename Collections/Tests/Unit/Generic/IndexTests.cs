using Woody230.Collections.Generic;

namespace Woody230.Collections.Tests.Unit.Generic;
public class IndexTests
{
    [Fact]
    public void WithIndex()
    {
        // Arrange
        var list = new List<int>() { 5, 9, 17 };

        // Act
        IEnumerable<(int, int)> withIndex = list.WithIndex();

        // Assert
        withIndex.Should().BeEquivalentTo(
        [
            (0, 5),
            (1, 9),
            (2, 17)
        ]);
    }
}
