using FluentAssertions;
using Woody230.Collections.Generic;
using Xunit;

namespace Woody230.Collections.Tests.Unit.Generic;
public class AddTests
{
    [Fact]
    public void AddAll()
    {
        // Arrange / Act
        List<int> list = new List<int>() { 4 };
        list.AddAll(new List<int>() { 99, 275, 82 });
        list.AddAll(553, 281, 99, 9102);

        // Assert
        list.Should().BeEquivalentTo(new List<int>()
        {
            4, 99, 275, 82, 553, 281, 99, 9102
        });
    }
}
