using System.Text;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Tests.Unit.Generic;
public class ForEachTests
{
    [Fact]
    public void ForEach()
    {
        // Arrange / Act
        var builder = new StringBuilder();

        HashSet<int> set = new HashSet<int>() { 4, 7, 9 };
        set.ForEach((int item) => builder.Append(item));
        builder.Append(' ');

        set.ForEach((int item) => builder.Append(item + 1), Postfix);
        builder.Append(' ');

        set.ForEach(Append);

        // Assert
        builder.ToString().Should().BeEquivalentTo("479 5-8-10- 6911");

        void Postfix(int _) => builder.Append('-');
        void Append(int item) => builder.Append(item + 2);
    }

    [Fact]
    public void ForEachIndexed()
    {
        // Arrange / Act
        var builder = new StringBuilder();

        HashSet<int> set = new HashSet<int>() { 4, 7, 9 };
        set.ForEachIndexed((int index, int item) => builder.Append(item + index));
        builder.Append(' ');

        set.ForEachIndexed(Append, Postfix);

        // Assert
        builder.ToString().Should().BeEquivalentTo("4811 5-9-12-");

        void Postfix(int _, int __) => builder.Append('-');
        void Append(int index, int item) => builder.Append(item + index + 1);
    }
}
