using FluentAssertions;
using System.Collections.Generic;
using Woody230.Collections.Generic;
using Xunit;

namespace Woody230.Collections.Tests.Unit.Generic;
public class ContainsAllTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void ContainsAll(IList<int> first, IList<int> second, bool expected)
    {
        first.ContainsAll(second).Should().Be(expected);
    }

    public static IEnumerable<object[]> Data()
    {
        yield return new object[]
        {
            new List<int>() { 1, 5, 9, 14, 99 },
            new List<int>() { 9 },
            true
        };

        yield return new object[]
        {
            new List<int>() { 9 },
            new List<int>() { 1, 5, 9, 14, 99 },
            false
        };

        yield return new object[]
        {
            new List<int>() { 1, 5, 9, 14, 99 },
            new List<int>() { 1, 5, 9, 14, 99 },
            true
        };

        yield return new object[]
        {
            new List<int>() { 1, 5, 9, 14, 99 },
            new List<int>() { 5, 14 },
            true
        };

        yield return new object[]
        {
            new List<int>() { 1, 5, 9, 14, 99 },
            new List<int>() { 2, 5, 14 },
            false
        };

        yield return new object[]
        {
            new List<int>() { 1, 5, 9, 14, 99 },
            new List<int>() { 5, 99, 1029 },
            false
        };

        yield return new object[]
        {
            new List<int>() { 1, 5, 9, 14, 99 },
            new List<int>() { 7, 173, 1029 },
            false
        };
    }
}
