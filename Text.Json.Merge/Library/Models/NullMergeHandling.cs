namespace Woody230.Text.Json.Merge.Models;

/// <summary>
/// How to merge null values.
/// </summary>
public enum NullMergeHandling
{
    /**
     * Null values are ignored during merging.
     */
    Ignore,

    /**
     * Null values are allowed to be merged.
     */
    Merge
}
