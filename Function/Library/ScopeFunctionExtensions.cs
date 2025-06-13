namespace Woody230.Function;

/// <summary>
/// Represents extensions mimicking scope functions from Kotlin.
/// </summary>
/// <seealso href="https://kotlinlang.org/docs/scope-functions.html"/>
public static class ScopeFunctionExtensions
{
    /// <summary>
    /// Invokes the <paramref name="action"/>.
    /// </summary>
    /// <returns>The <paramref name="object"/>.</returns>
    public static T Apply<T>(this T @object, Action action)
    {
        action();
        return @object;
    }

    /// <summary>
    /// Invokes the <paramref name="action"/> using the <paramref name="object"/>.
    /// </summary>
    /// <returns>The <paramref name="object"/>.</returns>
    public static T Apply<T>(this T @object, Action<T> action)
    {
        action(@object);
        return @object;
    }

    /// <summary>
    /// Invokes the <paramref name="function"/>.
    /// </summary>
    /// <returns>The <paramref name="object"/>.</returns>
    public static T Apply<T, R>(this T @object, Func<R> function)
    {
        function();
        return @object;
    }

    /// <summary>
    /// Invokes the <paramref name="function"/> using the <paramref name="object"/>.
    /// </summary>
    /// <returns>The <paramref name="object"/>.</returns>
    public static T Apply<T, R>(this T @object, Func<T, R> function)
    {
        function(@object);
        return @object;
    }

    /// <summary>
    /// Invokes the <paramref name="function"/> using the <paramref name="object"/>
    /// </summary>
    /// <returns>The result of the <paramref name="function"/>.</returns>
    public static R Run<T, R>(this T @object, Func<T, R> function)
    {
        return function(@object);
    }
}
