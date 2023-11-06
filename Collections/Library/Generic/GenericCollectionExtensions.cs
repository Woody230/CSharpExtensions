using System.Collections;

namespace Woody230.Collections.Generic;

/// <summary>
/// Represents extensions for generic collections.
/// </summary>
public static class GenericCollectionExtensions
{
    /// <summary>
    /// Adds each item in the <paramref name="other"/> collection to <paramref name="this"/> collection.
    /// </summary>
    public static void AddAll<T>(this ICollection<T> @this, IEnumerable<T> other)
    {
        foreach (var item in other)
        {
            @this.Add(item);
        }
    }

    /// <summary>
    /// Adds each item in the <paramref name="other"/> collection to <paramref name="this"/> collection.
    /// </summary>
    public static void AddAll<T>(this ICollection<T> @this, params T[] other)
    {
        AddAll(@this, other.ToList());
    }

    /// <summary>
    /// Removes each item in the <paramref name="other"/> collection from <paramref name="this"/> collection.
    /// </summary>
    public static void RemoveAll<T>(this ICollection<T> @this, IEnumerable<T> other)
    {
        foreach (var item in other)
        {
            @this.Remove(item);
        }
    }

    /// <summary>
    /// Removes each item in the <paramref name="other"/> collection from <paramref name="this"/> collection.
    /// </summary>
    public static void RemoveAll<T>(this ICollection<T> @this, params T[] other)
    {
        RemoveAll(@this, other.ToList());
    }

    /// <summary>
    /// Applies the <paramref name="actions"/> on each item in the collection.
    /// </summary>
    public static void ForEach<T>(this IEnumerable<T> @this, params Action<T>[] actions)
    {
        foreach (var item in @this)
        {
            foreach (var action in actions)
            {
                action(item);
            }
        }
    }

    /// <summary>
    /// Applies the <paramref name="actions"/> on each item in the collection with the associated position in the iteration.
    /// </summary>
    public static void ForEachIndexed<T>(this IEnumerable<T> @this, params Action<int, T>[] actions)
    {
        foreach (var (index, item) in WithIndex(@this)) 
        {
            foreach (var action in actions)
            {
                action(index, item);
            }
        }
    }

    /// <summary>
    /// Combines each item in <paramref name="this"/> collection with its position in the iteration.
    /// </summary>
    public static IEnumerable<(int, T)> WithIndex<T>(this IEnumerable<T> @this)
    {
        var index = 0;
        foreach (var item in @this)
        {
            yield return (index, item);
            index += 1;
        }
    }

    /// <summary>
    /// Determines whether all items in the <paramref name="other"/> collection are contained in <paramref name="this"/> collection.
    /// </summary>
    public static bool ContainsAll<T>(this ICollection<T> @this, IEnumerable<T> other)
    {
        return other.All(item => @this.Contains(item));
    }

    /// <summary>
    /// Determines whether <paramref name="this"/> collection is null or has no items.
    /// </summary>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
    {
        return @this == null || !@this.Any();
    }

    /// <summary>
    /// Determines whether <paramref name="this"/> collection is not null or has items.
    /// </summary>
    public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> @this)
    {
        return !IsNullOrEmpty(@this);
    }

    /// <summary>
    /// Filters <paramref name="this"/> collection based on the <paramref name="filter"/> being false.
    /// </summary>
    /// <returns>A new collection with items that did not pass the <paramref name="filter"/>.</returns>
    public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> @this, Func<T, bool> filter)
    {
        return @this.Where(item => !filter(item));
    }

    /// <summary>
    /// Filters <paramref name="this"/> collection based on the item being a null value.
    /// </summary>
    public static IEnumerable<T> WhereNull<T>(this IEnumerable<T> @this)
    {
        return @this.Where(item => item == null);
    }

    /// <summary>
    /// Filters <paramref name="this"/> collection based on the item NOT being a null value.
    /// </summary>
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> @this)
    {
        return @this.Where(item => item != null);
    }

    /// <summary>
    /// Filters <paramref name="this"/> collection based on the item being the default value of <typeparamref name="T"/>
    /// </summary>
    public static IEnumerable<T> WhereDefault<T>(this IEnumerable<T> @this)
    {
        var @default = default(T);
        return @this.Where(item => @default == null ? item == null : @default.Equals(item));
    }

    /// <summary>
    /// Filters <paramref name="this"/> collection based on the item NOT being the default value of <typeparamref name="T"/>
    /// </summary>
    public static IEnumerable<T> WhereNotDefault<T>(this IEnumerable<T> @this)
    {
        var @default = default(T);
        return @this.Where(item => @default == null ? item != null : !@default.Equals(item));
    }

    /// <summary>
    /// Filters <paramref name="this"/> collection based on the item being an instance of <typeparamref name="TInstance"/>.
    /// </summary>
    public static IEnumerable<TInstance> WhereInstanceOf<TInstance>(this IEnumerable @this)
    {
        foreach (var item in @this)
        {
            if (item is TInstance instance)
            {
                yield return instance;
            }
        }
    }

    /// <summary>
    /// Determines whether all items in <paramref name="this"/> collection do NOT pass the <paramref name="filter"/>.
    /// </summary>
    public static bool None<T>(this IEnumerable<T> @this, Func<T, bool> filter)
    {
        return !@this.Any(filter);
    }
    
    /// <summary>
    /// Concatenates all items in <paramref name="this"/> collection after converting them <paramref name="toString"/>, using the <paramref name="separator"/> between each item.
    /// </summary>
    public static string JoinToString<T>(this IEnumerable<T> @this, string separator, Func<T, string?> toString)
    {
        var stringified = @this.Select(toString);
        return string.Join(separator, stringified);
    }

    /// <summary>
    /// Concatenates all items in <paramref name="this"/> collection after converting them <paramref name="toString"/>, using a comma delimiter between each item.
    /// </summary>
    public static string JoinToString<T>(this IEnumerable<T> @this, Func<T, string?> toString)
    {
        return JoinToString(@this, ", ", toString);
    }

    /// <summary>
    /// Concatenates all items in <paramref name="this"/> collection after converting them to a string, using the <paramref name="separator"/> between each item.
    /// </summary>
    public static string JoinToString<T>(this IEnumerable<T> @this, string separator)
    {
        return JoinToString(@this, separator, item => item?.ToString());
    }

    /// <summary>
    /// Concatenates all items in <paramref name="this"/> collection after converting them to a string, using a comma delimiter between each item.
    /// </summary>
    public static string JoinToString<T>(this IEnumerable<T> @this)
    {
        return JoinToString(@this, ", ", item => item?.ToString());
    }
}
