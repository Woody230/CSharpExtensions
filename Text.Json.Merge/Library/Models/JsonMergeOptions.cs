namespace Woody230.Text.Json.Merge.Models;

/// <summary>
/// The options for merging JSON nodes.
/// </summary>
public sealed record JsonMergeOptions
{
    /// <summary>
    /// How to merge arrays.
    /// </summary>
    public required ArrayMergeHandling ArrayHandling { get; init; } = ArrayMergeHandling.Merge;

    /// <summary>
    /// How to merge null values.
    /// </summary>
    public required NullMergeHandling NullHandling { get; init; } = NullMergeHandling.Ignore;
}
