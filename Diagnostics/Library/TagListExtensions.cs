using System.Diagnostics;

namespace Woody230.Diagnostics;

/// <summary>
/// Represents extensions for a <see cref="TagList"/>
/// </summary>
public static class TagListExtensions
{
    public static TagList With(this TagList @this, string key, object? value)
    {
        @this.Add(key, value);
        return @this;
    }

    public static TagList With(this TagList @this, KeyValuePair<string, object?> tag)
    {
        @this.Add(tag);
        return @this;
    }

    public static TagList With(this TagList @this, params KeyValuePair<string, object?>[] tags)
    {
        foreach (var tag in tags)
        {
            @this.Add(tag);
        }

        return @this;
    }

    public static TagList With(this TagList @this, IEnumerable<KeyValuePair<string, object?>> tags)
    {
        foreach (var tag in tags)
        {
            @this.Add(tag);
        }

        return @this;
    }

    public static TagList With(this TagList @this, in TagList tags)
    {
        foreach (var tag in tags)
        {
            @this.Add(tag);
        }

        return @this;
    }

    public static TagList ToTagList(this IEnumerable<KeyValuePair<string, object?>>? @this)
    {
        var tags = new TagList();
        if (@this == null)
        {
            return tags;
        }

        return tags.With(@this);
    }
}
