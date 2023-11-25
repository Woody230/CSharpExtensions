using System.Text;

namespace Woody230.Resource;

/// <summary>
/// Resolves resources from a <see cref="Uri"/>.
/// </summary>
public interface IResourceResolver
{
    /// <summary>
    /// Gets the contents of a resource located associated with the <see cref="Uri"/> asynchronously with the given <paramref name="encoding"/>.
    /// </summary>
    public Task<string> ResolveAsync(Uri uri, Encoding encoding, CancellationToken cancellationToken);
}
