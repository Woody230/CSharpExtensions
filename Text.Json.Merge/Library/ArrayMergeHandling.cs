namespace Woody230.Text.Json.Merge;

/// <summary>
/// How to merge arrays.
/// </summary>
public enum ArrayMergeHandling
{
    /// <summary>
    /// Appends the nodes.
    /// </summary>
    Concat,

    /// <summary>
    /// Skips nodes that already exist.
    /// </summary>
    Union,

    /// <summary>
    /// Replaces the nodes.
    /// </summary>
    Replace,

    /// <summary>
    /// Replaces the nodes within the same index.
    /// </summary>
    Merge
}
