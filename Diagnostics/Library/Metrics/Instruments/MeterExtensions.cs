using System.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Metrics.Instruments;

/// <summary>
/// Represents extensions for a <see cref="Meter"/>.
/// </summary>
public static class MeterExtensions
{
    #region TimeSpanCounter

    /// <summary>
    /// Shorthand for creating a new <see cref="TimeSpanCounter"/> using one of the other extensions:
    /// <list type="bullet">
    ///     <item><see cref="CreateDayCounter(Meter, InstrumentOptions)"/></item>
    ///     <item><see cref="CreateHourCounter(Meter, InstrumentOptions)"/></item>
    ///     <item><see cref="CreateMinuteCounter(Meter, InstrumentOptions)"/></item>
    ///     <item><see cref="CreateSecondCounter(Meter, InstrumentOptions)"/></item>
    ///     <item><see cref="CreateMillisecondCounter(Meter, InstrumentOptions)"/></item>
    ///     <item><see cref="CreateMicrosecondCounter(Meter, InstrumentOptions)"/></item>
    ///     <item><see cref="CreateNanosecondCounter(Meter, InstrumentOptions)"/></item>
    /// </list>
    /// </summary>
    /// <param name="meter">The meter.</param>
    /// <param name="options">The instrument options.</param>
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

    /// <summary>
    /// <para>
    /// Creates a <see cref="TimeSpanCounter"/> with a <see cref="TimeInterval"/> of <see cref="TimeInterval.Days"/>.
    /// </para>
    /// <para>
    /// If the <see cref="InstrumentOptions.Unit"/> is null, it is defaulted to <see cref="InstrumentUnit.Day"/>.
    /// </para>
    /// </summary>
    /// <param name="meter">The meter.</param>
    /// <param name="options">The instrument options.</param>
    public static TimeSpanCounter CreateDayCounter(this Meter meter, InstrumentOptions options)
    {
        return InternalCreateTimeSpanCounter(meter, options, InstrumentUnit.Day, TimeInterval.Days);
    }

    /// <summary>
    /// <para>
    /// Creates a <see cref="TimeSpanCounter"/> with a <see cref="TimeInterval"/> of <see cref="TimeInterval.Hours"/>.
    /// </para>
    /// <para>
    /// If the <see cref="InstrumentOptions.Unit"/> is null, it is defaulted to <see cref="InstrumentUnit.Hour"/>.
    /// </para>
    /// </summary>
    /// <param name="meter">The meter.</param>
    /// <param name="options">The instrument options.</param>
    public static TimeSpanCounter CreateHourCounter(this Meter meter, InstrumentOptions options)
    {
        return InternalCreateTimeSpanCounter(meter, options, InstrumentUnit.Hour, TimeInterval.Hours);
    }

    /// <summary>
    /// <para>
    /// Creates a <see cref="TimeSpanCounter"/> with a <see cref="TimeInterval"/> of <see cref="TimeInterval.Minutes"/>.
    /// </para>
    /// <para>
    /// If the <see cref="InstrumentOptions.Unit"/> is null, it is defaulted to <see cref="InstrumentUnit.Minute"/>.
    /// </para>
    /// </summary>
    /// <param name="meter">The meter.</param>
    /// <param name="options">The instrument options.</param>
    public static TimeSpanCounter CreateMinuteCounter(this Meter meter, InstrumentOptions options)
    {
        return InternalCreateTimeSpanCounter(meter, options, InstrumentUnit.Minute, TimeInterval.Minutes);
    }

    /// <summary>
    /// <para>
    /// Creates a <see cref="TimeSpanCounter"/> with a <see cref="TimeInterval"/> of <see cref="TimeInterval.Seconds"/>.
    /// </para>
    /// <para>
    /// If the <see cref="InstrumentOptions.Unit"/> is null, it is defaulted to <see cref="InstrumentUnit.Second"/>.
    /// </para>
    /// </summary>
    /// <param name="meter">The meter.</param>
    /// <param name="options">The instrument options.</param>
    public static TimeSpanCounter CreateSecondCounter(this Meter meter, InstrumentOptions options)
    {
        return InternalCreateTimeSpanCounter(meter, options, InstrumentUnit.Second, TimeInterval.Seconds);
    }

    /// <summary>
    /// <para>
    /// Creates a <see cref="TimeSpanCounter"/> with a <see cref="TimeInterval"/> of <see cref="TimeInterval.Milliseconds"/>.
    /// </para>
    /// <para>
    /// If the <see cref="InstrumentOptions.Unit"/> is null, it is defaulted to <see cref="InstrumentUnit.Millisecond"/>.
    /// </para>
    /// </summary>
    /// <param name="meter">The meter.</param>
    /// <param name="options">The instrument options.</param>
    public static TimeSpanCounter CreateMillisecondCounter(this Meter meter, InstrumentOptions options)
    {
        return InternalCreateTimeSpanCounter(meter, options, InstrumentUnit.Millisecond, TimeInterval.Milliseconds);
    }

#if NET8_0_OR_GREATER

    /// <summary>
    /// <para>
    /// Creates a <see cref="TimeSpanCounter"/> with a <see cref="TimeInterval"/> of <see cref="TimeInterval.Microsceonds"/>.
    /// </para>
    /// <para>
    /// If the <see cref="InstrumentOptions.Unit"/> is null, it is defaulted to <see cref="InstrumentUnit.Microsecond"/>.
    /// </para>
    /// </summary>
    /// <param name="meter">The meter.</param>
    /// <param name="options">The instrument options.</param>
    public static TimeSpanCounter CreateMicrosecondCounter(this Meter meter, InstrumentOptions options)
    {
        return CreateTimeSpanCounter(meter, options with { Unit = InstrumentUnit.Microsecond }, TimeInterval.Microsceonds);
    }

    /// <summary>
    /// <para>
    /// Creates a <see cref="TimeSpanCounter"/> with a <see cref="TimeInterval"/> of <see cref="TimeInterval.Nanoseconds"/>.
    /// </para>
    /// <para>
    /// If the <see cref="InstrumentOptions.Unit"/> is null, it is defaulted to <see cref="InstrumentUnit.Nanosecond"/>.
    /// </para>
    /// </summary>
    /// <param name="meter">The meter.</param>
    /// <param name="options">The instrument options.</param>
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

    /// <summary>
    /// <para>
    /// Creates a <see cref="OccurrenceInstrument"/> using the <paramref name="options"/> as a baseline for the subinstruments.
    /// </para>
    /// <para>
    /// The occurrence counter uses: 
    /// <list type="bullet">
    ///     <item><see cref="InstrumentOptions.Name"/> and appends <b>.count</b></item>
    ///     <item><see cref="InstrumentOptions.Description"/> and prepends <b>Count of</b></item>
    ///     <item><see cref="InstrumentOptions.Unit"/> as is</item>
    ///     <item>All other <see cref="InstrumentOptions"/> are unchanged.</item>
    /// </list>
    /// </para>
    /// <para>
    /// The time counter uses:
    /// <list type="bullet">
    ///     <item><see cref="InstrumentOptions.Name"/> and appends <b>.time</b>.</item>
    ///     <item><see cref="InstrumentOptions.Description"/> and prepends <b>Time spent</b></item>
    ///     <item><see cref="InstrumentOptions.Unit"/> as the unit associated with the <paramref name="interval"/>. For example, milliseconds would use ms.</item>
    ///     <item>All other <see cref="InstrumentOptions"/> are unchanged.</item>
    /// </list>
    /// </para>
    /// </summary>
    /// <param name="meter">The meter.</param>
    /// <param name="options">The instrument options.</param>
    /// <param name="interval">The time interval to record.</param>
    public static OccurrenceInstrument CreateOccurrenceInstrument(this Meter meter, InstrumentOptions options, TimeInterval interval)
    {
        var occurrenceOptions = options with { Name = options.Name + ".count", Description = "Count of " + options.Description };
        var occurrenceCounter = meter.CreateCounter<long>(occurrenceOptions);

        var timeOptions = options with { Name = options.Name + ".time", Unit = null, Description = "Time spent " + options.Description };
        var timeCounter = meter.CreateTimeSpanCounter(timeOptions, interval);
        return new(meter, options, occurrenceCounter, timeCounter);
    }
    #endregion
}
