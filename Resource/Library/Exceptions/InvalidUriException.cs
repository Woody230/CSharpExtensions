namespace Woody230.Resource;

/// <summary>
/// Represents an exception where the resource cannot be loaded because the URI is not formatted correctly.
/// </summary>
public class InvalidUriException : ResourceException
{
    /// <summary>
    /// The invalid URI.
    /// </summary>
    public Uri Uri { get; }

    /// <summary>
    /// Initializes a new <see cref="InvalidUriException"/> with a default message.
    /// </summary>
    public InvalidUriException(Uri uri) : this(uri, null)
    {
    }

    /// <summary>
    /// Initializes a new <see cref="InvalidUriException"/> with the default message combined with the given <paramref name="message"/>.
    /// </summary>
    public InvalidUriException(Uri uri, string? message) : this(uri, message, null)
    {
    }

    /// <summary>
    /// Initializes a new <see cref="InvalidUriException"/> with the default message combined with the given <paramref name="message"/>.
    /// </summary>
    public InvalidUriException(Uri uri, string? message, Exception? innerException) : base(FormattedMessage(uri, message), innerException)
    {
        Uri = uri;
    }

    private static string FormattedMessage(Uri uri, string? message)
    {
        var formatted = $"URI {uri.OriginalString} is not correctly formatted";
        if (!string.IsNullOrWhiteSpace(message))
        {
            formatted += $" because {message}";
        }

        return formatted;
    }
}
