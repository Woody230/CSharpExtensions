using System.Text.Json.Nodes;

namespace Woody230.Text.Json.Merge.Tests.Unit;

public class JsonNodeMergeExtensionsTests
{
    [Fact]
    public void MergeArraySelf()
    {
        var sut = new JsonArray
        {
            JsonValue.Create("1"),
            JsonValue.Create("2")
        };

        var options = new JsonMergeOptions
        {
            ArrayHandling = ArrayMergeHandling.Replace
        };

        var actual = sut.Merge(sut, options);

        Assert(actual, sut);
    }

    [Fact]
    public void MergeObjectSelf()
    {
        var sut = new JsonObject
        {
            ["1"] = JsonValue.Create(1),
            ["2"] = JsonValue.Create(2)
        };

        var actual = sut.Merge(sut);

        Assert(actual, sut);
    }

    [Fact]
    public void MergeArrayIntoArray_Replace()
    {
        var sut = new JsonArray
        {
            JsonValue.Create("1"),
            JsonValue.Create("2")
        };

        var expected = new JsonArray
        {
            JsonValue.Create("3"),
            JsonValue.Create("4")
        };

        var options = new JsonMergeOptions
        {
            ArrayHandling = ArrayMergeHandling.Replace
        };

        var actual = sut.Merge(expected, options);

        Assert(actual, expected);
    }

    [Fact]
    public void MergeArrayIntoArray_Concat()
    {
        var sut = new JsonArray
        {
            JsonValue.Create("1"),
            JsonValue.Create("2")
        };

        var merge = new JsonArray
        {
            JsonValue.Create("2"),
            JsonValue.Create("3"),
            JsonValue.Create("4")
        };

        var expected = new JsonArray
        {
            JsonValue.Create("1"),
            JsonValue.Create("2"),
            JsonValue.Create("2"),
            JsonValue.Create("3"),
            JsonValue.Create("4")
        };

        var options = new JsonMergeOptions
        {
            ArrayHandling = ArrayMergeHandling.Concat
        };

        var actual = sut.Merge(merge, options);

        Assert(actual, expected);
    }

    [Fact]
    public void MergeArrayIntoArray_Union()
    {
        var sut = new JsonArray
        {
            JsonValue.Create("1"),
            JsonValue.Create("2")
        };

        var merge = new JsonArray
        {
            JsonValue.Create("2"),
            JsonValue.Create("3"),
            JsonValue.Create("4")
        };

        var expected = new JsonArray
        {
            JsonValue.Create("1"),
            JsonValue.Create("2"),
            JsonValue.Create("3"),
            JsonValue.Create("4")
        };

        var options = new JsonMergeOptions
        {
            ArrayHandling = ArrayMergeHandling.Union
        };

        var actual = sut.Merge(merge, options);

        Assert(actual, expected);
    }

    [Fact]
    public void MergeArrayIntoArray_Merge()
    {
        var sut = new JsonArray
        {
            JsonValue.Create("1"),
            JsonValue.Create("2")
        };

        var merge = new JsonArray
        {
            JsonValue.Create("2")
        };

        var expected = new JsonArray
        {
            JsonValue.Create("2"),
            JsonValue.Create("2")
        };

        var options = new JsonMergeOptions
        {
            ArrayHandling = ArrayMergeHandling.Merge
        };

        var actual = sut.Merge(merge, options);

        Assert(actual, expected);
    }

    [Fact]
    public void MergeNull()
    {
        var sut = new JsonObject
        {
            ["a"] = JsonValue.Create(1)
        };

        var merge = new JsonObject
        {
            ["a"] = null
        };

        var actual = sut.Merge(merge);

        Assert(actual, sut);
    }

    [Fact]
    public void MergeObjectProperty()
    {
        var sut = new JsonObject
        {
            ["Property1"] = JsonValue.Create(1)
        };

        var merge = new JsonObject
        {
            ["Property2"] = JsonValue.Create(2)
        };

        var expected = new JsonObject
        {
            ["Property1"] = JsonValue.Create(1),
            ["Property2"] = JsonValue.Create(2)
        };

        var actual = sut.Merge(merge);

        Assert(actual, expected);
    }

    [Fact]
    public void MergeChildObject()
    {
        var sut = new JsonObject
        {
            ["Property1"] = new JsonObject
            {
                ["SubProperty1"] = JsonValue.Create(1)
            }
        };

        var merge = new JsonObject
        {
            ["Property1"] = new JsonObject
            {
                ["SubProperty2"] = JsonValue.Create(2)
            }
        };

        var expected = new JsonObject
        {
            ["Property1"] = new JsonObject
            {
                ["SubProperty1"] = JsonValue.Create(1),
                ["SubProperty2"] = JsonValue.Create(2)
            }
        };

        var actual = sut.Merge(merge);

        Assert(actual, expected);
    }

    [Fact]
    public void MergeArrayOverwrite_Root()
    {
        var sut = new JsonArray
        {
            JsonValue.Create(1),
            JsonValue.Create(2),
            JsonValue.Create(3)
        };

            var expected = new JsonArray
        {
            JsonValue.Create(4),
            JsonValue.Create(5)
        };

        var options = new JsonMergeOptions
        {
            ArrayHandling = ArrayMergeHandling.Replace
        };

        var actual = sut.Merge(expected, options);

        Assert(actual, expected);
    }

    private void Assert(JsonNode actual, JsonNode expected)
    {
        actual.Should().NotBeNull();
        expected.Should().NotBeNull();

        JsonNode.DeepEquals(actual, expected).Should().BeTrue(
            $"Expected:\n{expected}\nActual:\n{actual}"
        );
    }
}