﻿using FluentAssertions;
using System.Collections.Generic;
using Woody230.Collections.Generic;
using Xunit;

namespace Woody230.Collections.Tests.Unit.Generic;
public class RemoveTests
{
    [Fact]
    public void RemoveAll()
    {
        // Arrange / Act
        List<int> list = new List<int>()
        {
            4, 99, 275, 82, 553, 281, 99, 9102
        }
        .RemoveAll(new List<int>() { 99, 275, 82 })
        .RemoveAll(553, 281, 99, 9102);

        // Assert
        list.Should().BeEquivalentTo(new List<int>() { 4 });
    }
}