namespace Woody230.Text.Json.Merge;

/// <summary>
/// How to merge null values.
/// </summary>
public enum NullMergeHandling
{
    /// <summary>
    /// Null values are ignored during merging.
    /// </summary>
    Ignore,

    /// <summary>
    /// Null values are allowed to be merged.
    /// </summary>
    Merge
}
