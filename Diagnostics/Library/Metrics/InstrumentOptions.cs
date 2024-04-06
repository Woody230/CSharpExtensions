using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics;

/// <summary>
/// Represents the options for configuring an <see cref="Instrument"/>.
/// </summary>
/// <param name="Name">The name of the instrument.</param>
public record InstrumentOptions(InstrumentName Name)
{
    /// <summary>
    /// The unit of measurement.
    /// </summary>
    public InstrumentUnit? Unit { get; init; }

    /// <summary>
    /// The description of the instrument.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// The tags to attach to the instrument.
    /// </summary>
    public TagList Tags { get; init; }
}
