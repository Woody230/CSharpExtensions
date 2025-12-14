using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Nodes;
using Woody230.Text.Json.Merge.Models;

namespace Woody230.Text.Json.Merge.Mergers;

/// <summary>
/// Combines JSON nodes.
/// </summary>
public sealed class JsonMerger(JsonMergeOptions options) : IJsonMerger
{
    /// <summary>
    /// A singleton instance of <see cref="JsonMerger"/> with <see cref="JsonMergeOptions.Default"/>.
    /// </summary>
    public static readonly JsonMerger Default = new(JsonMergeOptions.Default);

    /// <inheritdoc/>
    public JsonNode? Merge(JsonNode? first, JsonNode? second)
    {
        if (second is null || second.GetValueKind() == JsonValueKind.Null)
        {
            return MergeNull(first);
        }
        else if (first is JsonObject firstObject && second is JsonObject secondObject)
        {
            return Merge(firstObject, secondObject);
        }
        else if (first is JsonArray firstArray && second is JsonArray secondArray)
        {
            return Merge(firstArray, secondArray);
        }
        else
        {
            return second;
        }
    }

    private JsonNode? MergeNull(JsonNode? first) => options.NullHandling switch
    {
        NullMergeHandling.Ignore => first,
        NullMergeHandling.Merge => null,
        _ => first
    };

    /// <inheritdoc/>
    public JsonObject Merge(JsonObject first, JsonObject second)
    {
        var result = new JsonObject(second.Options);

        var keys = first.Select(k => k.Key).Concat(second.Select(k => k.Key)).ToList();
        foreach (var key in keys)
        {
            first.TryGetPropertyValue(key, out var firstProperty);
            second.TryGetPropertyValue(key, out var secondProperty);
            result[key] = Merge(firstProperty, secondProperty);
        }

        return result;
    }

    /// <inheritdoc/>
    public JsonArray Merge(JsonArray first, JsonArray second) => options.ArrayHandling switch
    {
        ArrayMergeHandling.Concat => Concat(first, second),
        ArrayMergeHandling.Union => Union(first, second),
        ArrayMergeHandling.Replace => second,
        ArrayMergeHandling.Merge => ReplaceByIndex(first, second),
        _ => second
    };

    private JsonArray Concat(JsonArray first, JsonArray second)
    {
        var result = new JsonArray(second.Options);
        foreach (var node in first.Concat(second))
        {
            result.Add(node);
        }

        return result;
    }

    private JsonArray Union(JsonArray first, JsonArray second)
    {
        var result = new JsonArray(second.Options);
        foreach (var node in first.Union(second))
        {
            result.Add(node);
        }

        return result;
    }

    private JsonArray ReplaceByIndex(JsonArray first, JsonArray second)
    {
        var result = new JsonArray(second.Options);

        var max = Math.Max(first.Count, second.Count);
        for (int i = 0; i < max; i++)
        {
            var firstNode = first.ElementAtOrDefault(i);
            var secondNode = second.ElementAtOrDefault(i);
            var mergedNode = Merge(firstNode, secondNode);
            result.Add(mergedNode);
        }

        return result;
    }
}
