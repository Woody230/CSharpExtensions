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
        IEnumerable<int> enumerable = set.ForEach((int item) => builder.Append(item));

        builder.Append(' ');
        set.ForEach((int item) => builder.Append(item + 1));

        builder.Append(' ');
        set.ForEach(Append);

        // Assert
        builder.ToString().Should().BeEquivalentTo("479 5810 6911");

        void Append(int item) => builder.Append(item + 2);
    }

    [Fact]
    public void ForEachIndexed()
    {
        // Arrange / Act
        var builder = new StringBuilder();

        HashSet<int> set = new HashSet<int>() { 4, 7, 9 };
        IEnumerable<int> enumerable = set.ForEachIndexed((int index, int item) => builder.Append(item + index));

        builder.Append(' ');
        set.ForEachIndexed(Append);

        // Assert
        builder.ToString().Should().BeEquivalentTo("4811 5912");

        void Append(int index, int item) => builder.Append(item + index + 1);
    }
}
