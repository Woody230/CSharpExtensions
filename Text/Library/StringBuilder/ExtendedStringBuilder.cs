namespace Woody230.Text.StringBuilder;

/// <summary>
/// Represents a <see cref="System.Text.StringBuilder"/> that is extended with additional functionality.
/// </summary>
public sealed class ExtendedStringBuilder: ExtensibleStringBuilder<ExtendedStringBuilder>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExtendedStringBuilder"/> class.
    /// </summary>
    /// <param name="builder">The string builder.</param>
    public ExtendedStringBuilder(System.Text.StringBuilder builder): base(builder)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtendedStringBuilder"/> class with a new string builder.
    /// </summary>
    public ExtendedStringBuilder() : base()
    {
    }
}
