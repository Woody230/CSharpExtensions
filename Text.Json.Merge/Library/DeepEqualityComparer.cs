using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;

namespace Woody230.Text.Json.Merge;

/// <summary>
/// Compares nodes using deep equality.
/// </summary>
internal sealed class DeepEqualityComparer : EqualityComparer<JsonNode?>
{
    public static readonly DeepEqualityComparer Instance = new();

    /// <inheritdoc/>
    public override bool Equals(JsonNode? x, JsonNode? y) => JsonNode.DeepEquals(x, y);

    /// <inheritdoc/>
    public override int GetHashCode([DisallowNull] JsonNode obj) => obj.ToJsonString().GetHashCode();
}
