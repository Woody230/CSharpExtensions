namespace Woody230.Text.Json.Merge.Models;

/// <summary>
/// How to merge arrays.
/// </summary>
public enum ArrayMergeHandling
{
    /**
     * Appends the elements.
     */
    Concat,

    /**
     * Skips elements that already exist.
     */
    Union,

    /**
     * Replaces the elements.
     */
    Replace,

    /**
     * Replaces the elements within the same index.
     */
    Merge
}
