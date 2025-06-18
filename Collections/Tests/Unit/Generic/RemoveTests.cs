using Woody230.Collections.Generic;

namespace Woody230.Collections.Tests.Unit.Generic;
public class RemoveTests
{
    [Fact]
    public void RemoveAll()
    {
        // Arrange / Act
        List<int> list = [4, 99, 275, 82, 553, 281, 99, 9102];
        list.RemoveAll(new List<int>() { 99, 275, 82 });
        list.RemoveAll(553, 281, 99, 9102);

        // Assert
        list.Should().BeEquivalentTo([4]);
    }
}
