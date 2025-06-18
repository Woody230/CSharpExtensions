using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics.Instruments;

/// <summary>
/// Provides the <see cref="InstrumentOptions"/> to the <see cref="Instrument"/>.
/// </summary>
public abstract class OptionsInstrument(Meter meter, InstrumentOptions options) : Instrument(meter, options.Name, options.Unit, options.Description, options.Tags)
{
}

/// <summary>
/// Provides the <see cref="InstrumentOptions"/> to the <see cref="Instrument{T}"/>.
/// </summary>
public abstract class OptionsInstrument<T>(Meter meter, InstrumentOptions options) : Instrument<T>(meter, options.Name, options.Unit, options.Description, options.Tags) where T : struct
{
}
