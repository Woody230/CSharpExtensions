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

        HashSet<int> set = new HashSet<int>() { 4, 7, 9 };
        set = set.ForEach((int item) => builder.Append(item));

        builder.Append(' ');
        IEnumerable<int> enumerable = set.ForEach(item => builder.Append(item + 1));

        // Assert
        builder.ToString().Should().BeEquivalentTo("479 5810");
    }

    [Fact]
    public void ForEachIndexed()
    {
        // Arrange / Act
        var builder = new StringBuilder();

        HashSet<int> set = new HashSet<int>() { 4, 7, 9 };
        set = set.ForEachIndexed((int index, int item) => builder.Append(item + index));

        // Assert
        builder.ToString().Should().BeEquivalentTo("4811");
    }
}
