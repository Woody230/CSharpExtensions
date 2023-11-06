using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Woody230.Collections.Generic;
using Xunit;

namespace Woody230.Collections.Tests.Unit.Generic;
public class AnyTests
{
    [Theory]
    [MemberData(nameof(AnyData))]
    public void Any(IList<int> list, bool expected)
    {
        list.Any(item => item < 0).Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(AnyData))]
    public void None(IList<int> list, bool unexpected)
    {
        list.None(item => item < 0).Should().Be(!unexpected);
    }

    public static IEnumerable<object[]> AnyData()
    {
        yield return new object[]
        {
            new List<int> { 1, 2, 3 },
            false
        };

        yield return new object[]
        {
            new List<int> { -1, 1, 2, 3 },
            true
        };

        yield return new object[]
        {
            new List<int>(),
            false
        };
    }
}
