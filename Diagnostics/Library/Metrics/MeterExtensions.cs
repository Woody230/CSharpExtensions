using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics;

/// <summary>
/// Represents extensions for a <see cref="Meter"/>.
/// </summary>
public static class MeterExtensions
{
    public static Counter<T> CreateCounter<T>(this Meter meter, InstrumentOptions options) where T: struct
    {
        return meter.CreateCounter<T>(options.Name, options.Unit, options.Description, options.Tags);
    }

    public static Histogram<T> CreateHistogram<T>(this Meter meter, InstrumentOptions options) where T: struct
    {
        return meter.CreateHistogram<T>(options.Name, options.Unit, options.Description, options.Tags);
    }

    public static ObservableCounter<T> CreateObservableCounter<T>(this Meter meter, Func<T> observeValue, InstrumentOptions options) where T : struct
    {
        return meter.CreateObservableCounter<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
    }

    public static ObservableCounter<T> CreateObservableCounter<T>(this Meter meter, Func<Measurement<T>> observeValue, InstrumentOptions options) where T : struct
    {
        return meter.CreateObservableCounter<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
    }

    public static ObservableCounter<T> CreateObservableCounter<T>(this Meter meter, Func<IEnumerable<Measurement<T>>> observeValue, InstrumentOptions options) where T : struct
    {
        return meter.CreateObservableCounter<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
    }

    public static ObservableGauge<T> CreateObservableGauge<T>(this Meter meter, Func<T> observeValue, InstrumentOptions options) where T : struct
    {
        return meter.CreateObservableGauge<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
    }

    public static ObservableGauge<T> CreateObservableGauge<T>(this Meter meter, Func<Measurement<T>> observeValue, InstrumentOptions options) where T : struct
    {
        return meter.CreateObservableGauge<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
    }

    public static ObservableGauge<T> CreateObservableGauge<T>(this Meter meter, Func<IEnumerable<Measurement<T>>> observeValue, InstrumentOptions options) where T : struct
    {
        return meter.CreateObservableGauge<T>(options.Name, observeValue, options.Unit, options.Description, options.Tags);
    }

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
}
