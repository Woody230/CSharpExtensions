using Microsoft.Extensions.Diagnostics.Metrics.Testing;
using Woody230.Diagnostics.Metrics.Instruments;

namespace Woody230.Diagnostics.Tests.Metrics.Instruments;

/// <summary>
/// Represents tests for a <see cref="TimeSpanCounter"/>
/// </summary>
public class TimeSpanCounterTests : InstrumentTests
{
    protected MetricCollector<double> Metrics { get; }

    public TimeSpanCounterTests()
    {
        Metrics = new(Meter, Options.Name);
    }

    [Theory]
    [InlineData(TimeInterval.Days)]
    [InlineData(TimeInterval.Hours)]
    [InlineData(TimeInterval.Minutes)]
    [InlineData(TimeInterval.Seconds)]
    [InlineData(TimeInterval.Milliseconds)]
    [InlineData(TimeInterval.Microseconds)]
    [InlineData(TimeInterval.Nanoseconds)]
    public void CreateInstrument_WithUnit_PersistsOptions(TimeInterval interval)
    {
        // Arrange
        var counter = Meter.CreateTimeSpanCounter(Options with { Unit = Unit }, interval);

        // Assert
        counter.Meter.Should().Be(Meter);
        counter.Name.Should().Be(Options.Name);
        counter.Unit.Should().Be(Unit);
        counter.Description.Should().Be(Options.Description);
        counter.Tags.ToTagList().Should().BeEquivalentTo(Options.Tags);
        counter.Enabled.Should().BeTrue();
        counter.IsObservable.Should().BeFalse();
    }

    [Theory]
    [InlineData(TimeInterval.Days, "d")]
    [InlineData(TimeInterval.Hours, "h")]
    [InlineData(TimeInterval.Minutes, "min")]
    [InlineData(TimeInterval.Seconds, "s")]
    [InlineData(TimeInterval.Milliseconds, "ms")]
    [InlineData(TimeInterval.Microseconds, "us")]
    [InlineData(TimeInterval.Nanoseconds, "ns")]
    [InlineData(TimeInterval.Unspecified, null)]
    public void CreateInstrument_WithoutUnit_SetsUnit(TimeInterval interval, string unit)
    {
        // Arrange
        var counter = Meter.CreateTimeSpanCounter(Options with { Unit = null }, interval);

        // Assert
        counter.Meter.Should().Be(Meter);
        counter.Name.Should().Be(Options.Name);
        counter.Unit.Should().Be(unit);
        counter.Description.Should().Be(Options.Description);
        counter.Tags.ToTagList().Should().BeEquivalentTo(Options.Tags);
        counter.Enabled.Should().BeTrue();
        counter.IsObservable.Should().BeFalse();
    }

    [Theory]
    [MemberData(nameof(IntervalData))]
    public void NoTags_RecordsTimeSpan(TimeInterval interval, TimeSpan elapsed, double value)
    {
        // Arrange
        var counter = Meter.CreateTimeSpanCounter(Options, interval);

        // Act
        counter.Add(elapsed);

        // Assert
        var measurements = Metrics.GetMeasurementSnapshot();
        measurements.Should().HaveCount(1);

        var measurement = measurements[0];
        measurement.Value.Should().Be(value);
        measurement.Tags.Should().BeEmpty();
    }

    [Theory]
    [MemberData(nameof(IntervalData))]
    public void WithTagList_RecordsTimeSpan(TimeInterval interval, TimeSpan elapsed, double value)
    {
        // Arrange
        var counter = Meter.CreateTimeSpanCounter(Options, interval);

        // Act
        counter.Add(elapsed, Tags);

        // Assert
        var measurements = Metrics.GetMeasurementSnapshot();
        measurements.Should().HaveCount(1);

        var measurement = measurements[0];
        measurement.Value.Should().Be(value);
        measurement.Tags.ToTagList().Should().BeEquivalentTo(Tags);
    }

    public static IEnumerable<object[]> IntervalData
    {
        get
        {
            yield return [
                TimeInterval.Unspecified,
                new TimeSpan(2, 12, 0, 0, 0, 0),
                0
            ];

            yield return [
                TimeInterval.Days,
                new TimeSpan(2, 12, 0, 0, 0, 0),
                2.5
            ];

            yield return [
                TimeInterval.Hours,
                new TimeSpan(0, 2, 30, 0, 0, 0),
                2.5
            ];

            yield return [
                TimeInterval.Minutes,
                new TimeSpan(0, 0, 2, 30, 0, 0),
                2.5
            ];

            yield return [
                TimeInterval.Seconds,
                new TimeSpan(0, 0, 0, 2, 500, 0),
                2.5
            ];

            yield return [
                TimeInterval.Milliseconds,
                new TimeSpan(0, 0, 0, 0, 2, 500),
                2.5
            ];

            yield return [
                TimeInterval.Microseconds,
                new TimeSpan(0, 0, 0, 0, 0, 2),
                2
            ];

            yield return [
                TimeInterval.Nanoseconds,
                new TimeSpan(0, 0, 0, 0, 0, 2),
                2000
            ];
        }
    }
}
