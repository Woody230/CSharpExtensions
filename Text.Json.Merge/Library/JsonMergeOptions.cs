namespace Woody230.Text.Json.Merge;

/// <summary>
/// The options for merging JSON nodes.
/// </summary>
public sealed record JsonMergeOptions
{
    /// <summary>
    /// A singleton instance of <see cref="JsonMergeOptions"/> with <see cref="ArrayMergeHandling.Merge"/> and <see cref="NullMergeHandling.Ignore"/>
    /// </summary>
    public static readonly JsonMergeOptions Default = new();

    /// <summary>
    /// How to merge arrays.
    /// </summary>
    public ArrayMergeHandling ArrayHandling { get; init; } = ArrayMergeHandling.Merge;

    /// <summary>
    /// How to merge null values.
    /// </summary>
    public NullMergeHandling NullHandling { get; init; } = NullMergeHandling.Ignore;
}
