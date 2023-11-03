using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using Woody230.Collections.Generic;
using Xunit;

namespace Woody230.Collections.Tests.Unit.Generic;
public class ForEachTests
{
    [Fact]
    public void ForEach()
    {
        // Arrange / Act
        var builder = new StringBuilder();

        HashSet<int> list = new HashSet<int>() { 4, 7, 9 };
        list = list.ForEach((int item) => builder.Append(item));

        builder.Append(' ');
        IEnumerable<int> enumerable = list.ForEach(item => builder.Append(item + 1));

        // Assert
        builder.ToString().Should().BeEquivalentTo("479 5810");
    }
}
