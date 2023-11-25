using System.IO.Abstractions;
using System.Text;

namespace Woody230.Resource.FileSystem;

/// <summary>
/// Resolves resources from the local file system.
/// </summary>
public class FileSystemResourceResolver : IResourceResolver
{
    private readonly IFileSystem _fileSystem;

    public FileSystemResourceResolver(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public Task<string> ResolveAsync(Uri uri, Encoding encoding, CancellationToken cancellationToken)
    {
        var path = GetPath(uri);
        return _fileSystem.File.ReadAllTextAsync(path, encoding, cancellationToken);
    }

    private string GetPath(Uri uri)
    {
        if (!uri.IsFile)
        {
            throw new InvalidUriException(uri, "a file is expected");
        }

        return uri.LocalPath;
    }
}
