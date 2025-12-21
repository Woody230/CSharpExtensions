using System.Text.Json.Nodes;

namespace Woody230.Text.Json.Merge;

/// <summary>
/// Combines JSON nodes.
/// </summary>
public interface IJsonMerger
{
    /// <summary>
    /// Combines the contents of the <paramref name="first"/> node with the <paramref name="second"/> node.
    /// </summary>
    /// <param name="first">The first node.</param>
    /// <param name="second">The second node.</param>
    /// <returns>The combined node.</returns>
    public JsonNode? Merge(JsonNode? first, JsonNode? second);

    /// <summary>
    /// Combines the contents of the <paramref name="first"/> object with the <paramref name="second"/> object.
    /// </summary>
    /// <param name="first">The first object.</param>
    /// <param name="second">The second object.</param>
    /// <returns>The combined object.</returns>
    public JsonObject Merge(JsonObject first, JsonObject second);

    /// <summary>
    /// Combines the contents of the <paramref name="first"/> array with the <paramref name="second"/> array.
    /// </summary>
    /// <param name="first">The first array.</param>
    /// <param name="second">The second array.</param>
    /// <returns>The combined array.</returns>
    public JsonArray Merge(JsonArray first, JsonArray second);
}
