using System.Text;

namespace Woody230.Resource;

/// <summary>
/// Represents extensions for a <see cref="IResourceResolver"/>.
/// </summary>
public static class ResourceResolverExtensions
{
    /// <summary>
    /// Gets the contents of a resource located associated with the <see cref="Uri"/> asynchronously with the given <paramref name="encoding"/>.
    /// </summary>
    public static string Resolve(this IResourceResolver @this, Uri uri, Encoding encoding)
    {
        return @this.ResolveAsync(uri, encoding, default).ConfigureAwait(false).GetAwaiter().GetResult();
    }
}
