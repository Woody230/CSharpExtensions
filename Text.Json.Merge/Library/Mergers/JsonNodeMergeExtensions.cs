using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;
using Woody230.Text.Json.Merge.Models;

namespace Woody230.Text.Json.Merge.Mergers;

/// <summary>
/// Represents extensions for merging <see cref="JsonNode"/>
/// </summary>
public static class JsonNodeMergeExtensions
{
    /// <summary>
    /// Combines the contents of the <paramref name="this"/> node with the <paramref name="other"/> node.
    /// </summary>
    /// <param name="this">The first node.</param>
    /// <param name="other">The second node.</param>
    /// <returns>The combined node.</returns>
    [return: NotNullIfNotNull(nameof(other))]
    public static JsonNode? Merge(this JsonNode @this, JsonNode? other)
    {
        return JsonMerger.Default.Merge(@this, other);
    }

    /// <summary>
    /// Combines the contents of the <paramref name="this"/> object with the <paramref name="other"/> object.
    /// </summary>
    /// <param name="this">The first object.</param>
    /// <param name="other">The second object.</param>
    /// <returns>The combined object.</returns>
    public static JsonObject Merge(this JsonObject @this, JsonObject other)
    {
        return JsonMerger.Default.Merge(@this, other);
    }

    /// <summary>
    /// Combines the contents of the <paramref name="this"/> array with the <paramref name="other"/> array.
    /// </summary>
    /// <param name="this">The first array.</param>
    /// <param name="other">The second array.</param>
    /// <returns>The combined array.</returns>
    public static JsonArray Merge(this JsonArray @this, JsonArray other)
    {
        return JsonMerger.Default.Merge(@this, other);
    }

    /// <summary>
    /// Combines the contents of the <paramref name="this"/> node with the <paramref name="other"/> node with custom merging options.
    /// </summary>
    /// <param name="this">The first node.</param>
    /// <param name="other">The second node.</param>
    /// <param name="options">The merging options.</param>
    /// <returns>The combined node.</returns>
    [return: NotNullIfNotNull(nameof(other))]
    public static JsonNode? Merge(this JsonNode @this, JsonNode? other, JsonMergeOptions options)
    {
        return new JsonMerger(options).Merge(@this, other);
    }

    /// <summary>
    /// Combines the contents of the <paramref name="this"/> object with the <paramref name="other"/> object with custom merging options.
    /// </summary>
    /// <param name="this">The first object.</param>
    /// <param name="other">The second object.</param>
    /// <param name="options">The merging options.</param>
    /// <returns>The combined object.</returns>
    public static JsonObject Merge(this JsonObject @this, JsonObject other, JsonMergeOptions options)
    {
        return new JsonMerger(options).Merge(@this, other);
    }

    /// <summary>
    /// Combines the contents of the <paramref name="this"/> array with the <paramref name="other"/> array with custom merging options.
    /// </summary>
    /// <param name="this">The first array.</param>
    /// <param name="other">The second array.</param>
    /// <param name="options">The merging options.</param>
    /// <returns>The combined array.</returns>
    public static JsonArray Merge(this JsonArray @this, JsonArray other, JsonMergeOptions options)
    {
        return new JsonMerger(options).Merge(@this, other);
    }
}
