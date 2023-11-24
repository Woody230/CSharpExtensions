using System.Runtime.Serialization;

namespace Woody230.Resource;

/// <summary>
/// Represents an exception where a resource cannot be loaded.
/// </summary>
public class ResourceException : Exception
{
    public ResourceException()
    {
    }

    public ResourceException(string? message) : base(message)
    {
    }

    public ResourceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ResourceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
