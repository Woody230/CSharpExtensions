using Microsoft.Extensions.Diagnostics.Metrics.Testing;
using System.Diagnostics;
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

    [Theory]
    [MemberData(nameof(IntervalData))]
    public void WithTagParams_RecordsTimeSpan(TimeInterval interval, TimeSpan elapsed, double value)
    {
        // Arrange
        var counter = Meter.CreateTimeSpanCounter(Options, interval);

        // Act
        counter.Add(elapsed, KeyValuePair.Create<string, object>("type", nameof(TimeSpanCounterTests)));

        // Assert
        var measurements = Metrics.GetMeasurementSnapshot();
        measurements.Should().HaveCount(1);

        var measurement = measurements[0];
        measurement.Value.Should().Be(value);
        measurement.Tags.ToTagList().Should().BeEquivalentTo(new TagList().With("type", nameof(TimeSpanCounterTests)));
    }


    public static IEnumerable<object[]> IntervalData
    {
        get
        {
            yield return [
                TimeInterval.Days,
                new TimeSpan(2, 12, 0, 0, 0, 0),
                2.5
            ];
        }
    }
}
