using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics;

/// <summary>
/// Represents extensions for an <see cref="Instrument"/>.
/// </summary>
public static class InstrumentExtensions
{
    /// <summary>
    /// Creates an <see cref="InstrumentOptions"/> with:
    /// <list type="bullet">
    ///     <item><see cref="InstrumentOptions.Name"/> as the <see cref="Instrument.Name"/> wrapped as an <see cref="InstrumentName"/></item>
    ///     <item><see cref="InstrumentOptions.Description"/> as the <see cref="Instrument.Description"/></item>
    ///     <item><see cref="InstrumentOptions.Unit"/> as the <see cref="Instrument.Unit"/> wrapped as an <see cref="InstrumentUnit?"/></item>
    ///     <item><see cref="InstrumentOptions.Tags"/> as the <see cref="Instrument.Tags"/> converted to a tag list</item>
    /// </list>
    /// </summary>
    /// <param name="instrument">The instrument.</param>
    public static InstrumentOptions GetOptions(this Instrument instrument) => new(instrument.Name)
    {
        Description = instrument.Description,
        Unit = instrument.Unit == null ? null : new(instrument.Unit),

#if NET8_0_OR_GREATER
        Tags = instrument.Tags.ToTagList(),
#endif
    };
}
