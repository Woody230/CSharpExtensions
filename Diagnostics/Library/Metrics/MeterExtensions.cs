using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics;

/// <summary>
/// Represents extensions for a <see cref="Meter"/>.
/// </summary>
public static class MeterExtensions
{
    public static Counter<T> CreateCounter<T>(this Meter meter, InstrumentOptions options) where T: struct
    {
#if NET6_0
        return meter.CreateCounter<T>(options.Name, options.Unit, options.Description);
#else
        return meter.CreateCounter<T>(options.Name, options.Unit, options.Description, options.Tags);
#endif
    }

    public static Histogram<T> CreateHistogram<T>(this Meter meter, InstrumentOptions options) where T: struct
    {
#if NET6_0
        return meter.CreateHistogram<T>(options.Name, options.Unit, options.Description);
#else
        return meter.CreateHistogram<T>(options.Name, options.Unit, options.Description, options.Tags);
#endif
    }

    public static ObservableCounter<T> CreateObservableCounter<T>(this Meter meter, Func<T> observeValue, InstrumentOptions options) where T : struct
    {
#if NET6_0
        return meter.CreateObservableCounter<T>(options.Name, observeValue, options.Unit, options.Description);
#else
        return meter.CreateObservableCounter<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
#endif
    }

    public static ObservableCounter<T> CreateObservableCounter<T>(this Meter meter, Func<Measurement<T>> observeValue, InstrumentOptions options) where T : struct
    {
#if NET6_0
        return meter.CreateObservableCounter<T>(options.Name, observeValue, options.Unit, options.Description);
#else
        return meter.CreateObservableCounter<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
#endif
    }

    public static ObservableCounter<T> CreateObservableCounter<T>(this Meter meter, Func<IEnumerable<Measurement<T>>> observeValue, InstrumentOptions options) where T : struct
    {
#if NET6_0
        return meter.CreateObservableCounter<T>(options.Name, observeValue, options.Unit, options.Description);
#else
        return meter.CreateObservableCounter<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
#endif
    }

    public static ObservableGauge<T> CreateObservableGauge<T>(this Meter meter, Func<T> observeValue, InstrumentOptions options) where T : struct
    {
#if NET6_0
        return meter.CreateObservableGauge<T>(options.Name, observeValue, options.Unit, options.Description);
#else
        return meter.CreateObservableGauge<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
#endif
    }

    public static ObservableGauge<T> CreateObservableGauge<T>(this Meter meter, Func<Measurement<T>> observeValue, InstrumentOptions options) where T : struct
    {
#if NET6_0
        return meter.CreateObservableGauge<T>(options.Name, observeValue, options.Unit, options.Description);
#else
        return meter.CreateObservableGauge<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
#endif
    }

    public static ObservableGauge<T> CreateObservableGauge<T>(this Meter meter, Func<IEnumerable<Measurement<T>>> observeValue, InstrumentOptions options) where T : struct
    {
#if NET6_0
        return meter.CreateObservableGauge<T>(options.Name, observeValue, options.Unit, options.Description);
#else
        return meter.CreateObservableGauge<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
#endif
    }

#if NET8_0_OR_GREATER
    public static ObservableUpDownCounter<T> CreateObservableUpDownCounter<T>(this Meter meter, Func<T> observeValue, InstrumentOptions options) where T : struct
    {
        return meter.CreateObservableUpDownCounter<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
    }

    public static ObservableUpDownCounter<T> CreateObservableUpDownCounter<T>(this Meter meter, Func<Measurement<T>> observeValue, InstrumentOptions options) where T : struct
    {
        return meter.CreateObservableUpDownCounter<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
    }

    public static ObservableUpDownCounter<T> CreateObservableUpDownCounter<T>(this Meter meter, Func<IEnumerable<Measurement<T>>> observeValue, InstrumentOptions options) where T : struct
    {
        return meter.CreateObservableUpDownCounter<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
    }

    public static UpDownCounter<T> CreateUpDownCounter<T>(this Meter meter, InstrumentOptions options) where T : struct
    {
        return meter.CreateUpDownCounter<T>(options.Name, options.Unit, options.Description, options.Tags);
    }
#endif

    public static TimeSpanCounter CreateTimeSpanCounter(this Meter meter, InstrumentOptions options, TimeInterval interval)
    {
        var counter = meter.CreateCounter<double>(options);
        return new TimeSpanCounter(counter, interval);
    }

    public static TimeSpanCounter CreateDayCounter(this Meter meter, InstrumentOptions options)
    {
        return CreateTimeSpanCounter(meter, options with { Unit = InstrumentUnit.Day }, TimeInterval.Days);
    }

    public static TimeSpanCounter CreateHourCounter(this Meter meter, InstrumentOptions options)
    {
        return CreateTimeSpanCounter(meter, options with { Unit = InstrumentUnit.Hour }, TimeInterval.Hours);
    }

    public static TimeSpanCounter CreateMinuteCounter(this Meter meter, InstrumentOptions options)
    {
        return CreateTimeSpanCounter(meter, options with { Unit = InstrumentUnit.Minute }, TimeInterval.Minutes);
    }

    public static TimeSpanCounter CreateSecondCounter(this Meter meter, InstrumentOptions options)
    {
        return CreateTimeSpanCounter(meter, options with { Unit = InstrumentUnit.Second }, TimeInterval.Seconds);
    }

    public static TimeSpanCounter CreateMillisecondCounter(this Meter meter, InstrumentOptions options)
    {
        return CreateTimeSpanCounter(meter, options with { Unit = InstrumentUnit.Millisecond }, TimeInterval.Milliseconds);
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
}
