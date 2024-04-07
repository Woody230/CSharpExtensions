using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics.Instruments;

/// <summary>
/// Represents extensions for a <see cref="Meter"/>.
/// </summary>
public static class MeterExtensions
{
    #region TimeSpanCounter
    public static TimeSpanCounter CreateTimeSpanCounter(this Meter meter, InstrumentOptions options, TimeInterval interval)
    {
        return interval switch
        {
            TimeInterval.Days => CreateDayCounter(meter, options),
            TimeInterval.Hours => CreateHourCounter(meter, options),
            TimeInterval.Minutes => CreateMinuteCounter(meter, options),
            TimeInterval.Seconds => CreateSecondCounter(meter, options),
            TimeInterval.Milliseconds => CreateMillisecondCounter(meter, options),
#if NET8_0_OR_GREATER
            TimeInterval.Microsceonds => CreateMicrosecondCounter(meter, options),
            TimeInterval.Nanoseconds => CreateNanosecondCounter(meter, options),
#endif
            _ => InternalCreateTimeSpanCounter(meter, options, null, interval),
        };
    }

    public static TimeSpanCounter CreateDayCounter(this Meter meter, InstrumentOptions options)
    {
        return InternalCreateTimeSpanCounter(meter, options, InstrumentUnit.Day, TimeInterval.Days);
    }

    public static TimeSpanCounter CreateHourCounter(this Meter meter, InstrumentOptions options)
    {
        return InternalCreateTimeSpanCounter(meter, options, InstrumentUnit.Hour, TimeInterval.Hours);
    }

    public static TimeSpanCounter CreateMinuteCounter(this Meter meter, InstrumentOptions options)
    {
        return InternalCreateTimeSpanCounter(meter, options, InstrumentUnit.Minute, TimeInterval.Minutes);
    }

    public static TimeSpanCounter CreateSecondCounter(this Meter meter, InstrumentOptions options)
    {
        return InternalCreateTimeSpanCounter(meter, options, InstrumentUnit.Second, TimeInterval.Seconds);
    }

    public static TimeSpanCounter CreateMillisecondCounter(this Meter meter, InstrumentOptions options)
    {
        return InternalCreateTimeSpanCounter(meter, options, InstrumentUnit.Millisecond, TimeInterval.Milliseconds);
    }

#if NET8_0_OR_GREATER
    public static TimeSpanCounter CreateMicrosecondCounter(this Meter meter, InstrumentOptions options)
    {
        return CreateTimeSpanCounter(meter, options with { Unit = InstrumentUnit.Microsecond }, TimeInterval.Microsceonds);
    }

    public static TimeSpanCounter CreateNanosecondCounter(this Meter meter, InstrumentOptions options)
    {
        return CreateTimeSpanCounter(meter, options with { Unit = InstrumentUnit.Nanosecond }, TimeInterval.Nanoseconds);
    }
#endif

    internal static TimeSpanCounter InternalCreateTimeSpanCounter(this Meter meter, InstrumentOptions options, InstrumentUnit? unit, TimeInterval interval)
    {
        return new TimeSpanCounter(meter, options with { Unit = options.Unit ?? unit }, interval);
    }

    #endregion TimeSpanCounter

    #region OccurrenceInstrument
    public static OccurrenceInstrument CreateOccurrenceInstrument(this Meter meter, InstrumentOptions options, TimeInterval interval)
    {
        var occurrenceCounter = meter.CreateCounter<long>(options);
        var timeCounter = meter.CreateTimeSpanCounter(options with { Unit = null }, interval);
        return new(meter, occurrenceCounter, timeCounter);
    }
    #endregion
}
