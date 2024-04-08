using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics.Instruments;

/// <summary>
/// Provides the <see cref="InstrumentOptions"/> to the <see cref="Instrument"/>.
/// </summary>
public abstract class OptionsInstrument: Instrument
{
    protected OptionsInstrument(Meter meter, InstrumentOptions options)
#if NET6_0
        : base(meter, options.Name, options.Unit, options.Description)
#else
        : base(meter, options.Name, options.Unit, options.Description, options.Tags)
#endif
    {
    }
}

/// <summary>
/// Provides the <see cref="InstrumentOptions"/> to the <see cref="Instrument{T}"/>.
/// </summary>
public abstract class OptionsInstrument<T> : Instrument<T> where T : struct
{
    protected OptionsInstrument(Meter meter, InstrumentOptions options)
#if NET6_0
        : base(meter, options.Name, options.Unit, options.Description)
#else
        : base(meter, options.Name, options.Unit, options.Description, options.Tags)
#endif
    {
    }
}
