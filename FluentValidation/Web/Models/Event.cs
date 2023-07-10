namespace Woody230.FluentValidation.Web.Models;

/// <summary>
/// Event
/// </summary>
public record Event
{
    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; init; }
}
