﻿using Microsoft.Extensions.Diagnostics.Metrics.Testing;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Woody230.Diagnostics.Metrics;
using Woody230.Diagnostics.Metrics.Instruments;

namespace Woody230.Diagnostics.Tests.Metrics.Instruments;

/// <summary>
/// Represents tests for the <see cref="TimedOccurrenceCounter"/>
/// </summary>
public class TimedOccurrenceCounterTests: InstrumentTests
{
    protected MetricCollector<long> OccurrenceMetrics { get; }
    protected MetricCollector<double> TimeMetrics { get; }
    protected long Occurrences { get; } = 5;
    
    public TimedOccurrenceCounterTests()
    {
        OccurrenceMetrics = new(Meter, Options.Name + ".count");
        TimeMetrics = new(Meter, Options.Name + ".time");
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
    public void CreateInstrument_WithoutUnit_PersistsOptions(TimeInterval interval, string timeUnit)
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options with { Unit = null }, interval);

        // Assert
        counter.Meter.Should().Be(Meter);
        counter.Name.Should().Be(Options.Name);
        counter.Unit.Should().BeNull();
        counter.Description.Should().Be(Options.Description);
        counter.Enabled.Should().BeTrue();

        counter._occurrenceCounter.Meter.Should().Be(Meter);
        counter._occurrenceCounter.Name.Should().Be($"{Options.Name}.count");
        counter._occurrenceCounter.Unit.Should().Be(InstrumentUnit.Unity);
        counter._occurrenceCounter.Description.Should().Be($"Count of {Options.Description}");
        counter._occurrenceCounter.Enabled.Should().BeTrue();

        counter._timeCounter.Meter.Should().Be(Meter);
        counter._timeCounter.Name.Should().Be($"{Options.Name}.time");
        counter._timeCounter.Unit.Should().Be(timeUnit);
        counter._timeCounter.Description.Should().Be($"Time spent {Options.Description}");
        counter._timeCounter.Enabled.Should().BeTrue();
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
    public void CreateInstrument_WithUnit_PersistsOptions(TimeInterval interval, string timeUnit)
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options with { Unit = Unit }, interval);

        // Assert
        counter.Meter.Should().Be(Meter);
        counter.Name.Should().Be(Options.Name);
        counter.Unit.Should().Be(Unit);
        counter.Description.Should().Be(Options.Description);
        counter.Enabled.Should().BeTrue();

        counter._occurrenceCounter.Meter.Should().Be(Meter);
        counter._occurrenceCounter.Name.Should().Be($"{Options.Name}.count");
        counter._occurrenceCounter.Unit.Should().Be(Unit);
        counter._occurrenceCounter.Description.Should().Be($"Count of {Options.Description}");
        counter._occurrenceCounter.Enabled.Should().BeTrue();

        counter._timeCounter.Meter.Should().Be(Meter);
        counter._timeCounter.Name.Should().Be($"{Options.Name}.time");
        counter._timeCounter.Unit.Should().Be(timeUnit);
        counter._timeCounter.Description.Should().Be($"Time spent {Options.Description}");
        counter._timeCounter.Enabled.Should().BeTrue();
    }

    #region Action No Count
    [Fact]
    public void RecordAction()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        counter.Record(() => Thread.Sleep(2));

        // Assert
        AssertMetrics();
    }

    [Fact]
    public void RecordAction_WithTags()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        counter.Record(() => Thread.Sleep(2), Tags);

        // Assert
        AssertMetrics(Tags);
    }

    [Fact]
    public void RecordAction_WithResultTags()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        counter.Record(() => Thread.Sleep(2), () => Tags);

        // Assert
        AssertMetrics(Tags);
    }
    #endregion Action No Count

    #region Action With Count

    [Fact]
    public void RecordAction_WithCount()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        counter.Record(() => Thread.Sleep(2), Occurrences);

        // Assert
        AssertMetrics(Occurrences);
    }

    [Fact]
    public void RecordAction_WithCount_WithTags()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        counter.Record(() => Thread.Sleep(2), Occurrences, Tags);

        // Assert
        AssertMetrics(Occurrences, Tags);
    }

    [Fact]
    public void RecordAction_WithCount_WithResultTags()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        counter.Record(() => Thread.Sleep(2), Occurrences, () => Tags);

        // Assert
        AssertMetrics(Occurrences, Tags);
    }

    #endregion Action With Count

    #region Function No Count
    [Fact]
    public void RecordFunction()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        var now = DateTime.Now;
        var result = counter.Record(() =>
        {
            Thread.Sleep(2);
            return now;
        });

        // Assert
        result.Should().Be(now);
        AssertMetrics();
    }

    [Fact]
    public void RecordFunction_WithTags()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        var now = DateTime.Now;
        var result = counter.Record(() =>
        {
            Thread.Sleep(2);
            return now;
        }, Tags);

        // Assert
        result.Should().Be(now);
        AssertMetrics(Tags);
    }

    [Fact]
    public void RecordFunction_WithResultTags()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        var now = DateTime.Now;
        var result = counter.Record(() =>
        {
            Thread.Sleep(2);
            return now;
        }, (result) =>
        {
            result.Should().Be(now);
            return Tags;
        });

        // Assert
        result.Should().Be(now);
        AssertMetrics(Tags);
    }

    #endregion Function No Count

    #region Function With Count
    [Fact]
    public void RecordFunction_WithCount()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        var now = DateTime.Now;
        var result = counter.Record(() =>
        {
            Thread.Sleep(2);
            return now;
        });

        // Assert
        result.Should().Be(now);
        AssertMetrics();
    }

    [Fact]
    public void RecordFunction_WithCount_WithTags()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        var now = DateTime.Now;
        var result = counter.Record(() =>
        {
            Thread.Sleep(2);
            return now;
        }, Occurrences, Tags);

        // Assert
        result.Should().Be(now);
        AssertMetrics(Occurrences, Tags);
    }

    [Fact]
    public void RecordFunction_WithCount_WithResultTags()
    {
        // Arrange
        var counter = Meter.CreateTimedOccurrenceCounter(Options, TimeInterval.Milliseconds);

        // Act
        var now = DateTime.Now;
        var result = counter.Record(() =>
        {
            Thread.Sleep(2);
            return now;
        }, Occurrences, (result) =>
        {
            result.Should().Be(now);
            return Tags;
        });

        // Assert
        result.Should().Be(now);
        AssertMetrics(Occurrences, Tags);
    }

    #endregion Function With Count

    private void AssertMetrics(TagList tags)
    {
        AssertMetrics(1, tags);
    }

    private void AssertMetrics(long count = 1, TagList? tags = null)
    {
        AssertOccurrence();
        AssertTime();

        void AssertOccurrence()
        {
            var measurements = OccurrenceMetrics.GetMeasurementSnapshot();
            measurements.Should().HaveCount(1);

            var measurement = measurements[0];
            measurement.Value.Should().Be(count);
            measurement.Tags.ToTagList().Should().BeEquivalentTo(tags ?? new TagList());
        }

        void AssertTime()
        {
            var measurements = TimeMetrics.GetMeasurementSnapshot();
            measurements.Should().HaveCount(1);

            var measurement = measurements[0];
            measurement.Value.Should().BeGreaterThan(2).And.BeLessThan(100, "should leniently finish in at least 100 ms");
            measurement.Tags.ToTagList().Should().BeEquivalentTo(tags ?? new TagList());
        }
    }
}
