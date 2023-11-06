using Woody230.Collections.Generic;

namespace Woody230.Collections.Tests.Unit.Generic;
public class NullOrEmptyTests
{
    [Theory]
    [MemberData(nameof(IsNullOrEmptyData))]
    public void IsNullOrEmpty(IList<int> list, bool expected)
    {
        list.IsNullOrEmpty().Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(IsNullOrEmptyData))]
    public void IsNotNullOrEmpty(IList<int> list, bool unexpected)
    {
        list.IsNotNullOrEmpty().Should().Be(!unexpected);
    }

    public static IEnumerable<object[]> IsNullOrEmptyData()
    {
        yield return new object[]
        {
            new List<int>() { 1, 2 },
            false
        };

        yield return new object[]
        {
            new List<int>() { 99 },
            false
        };

        yield return new object[]
        {
            new List<int>(),
            true
        };

        yield return new object[]
        {
            null,
            true
        };
    }
}
