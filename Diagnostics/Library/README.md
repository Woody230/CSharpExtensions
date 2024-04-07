![](https://img.shields.io/github/license/Woody230/CSharpExtensions)
[![](https://img.shields.io/nuget/v/Woody230.Diagnostics)](https://www.nuget.org/packages/Woody230.Diagnostics)

# Diagnostics

Extensions for the System.Diagnostics namespace.

## InstrumentOptions

```csharp
public InstrumentOptions GetInstrumentOptions() => new("instrument.name") 
{ 
	Description = "instrument.description", 
	Unit = "instrument.unit" 

	// .NET8
	Tags = new TagList()
};
```

## TimeSpanCounter

A counter that adds the total time for a specific time interval such as milliseconds.

```csharp
var options = GetInstrumentOptions();
var meter = GetMeter();
var counter = meter.CreateTimeSpanCounter(options, TimeInterval.Milliseconds);

var tags = new TagList();
counter.Add(new TimeSpan(2, 0, 0), tags);
```

## TimedOccurrenceCounter

An instrument that manages two counters:
1. Number of occurrences of an event using a long (via a standard `Counter`).
2. Time spent processing the event using a double (via a `TimeSpanCounter`).

An event is represented by the processing of an action or function. When an event is recorded:
1. The number of occurrences is incremented by one.
2. The time spent is incremented by the time elapsed according to a `Stopwatch` for a given `TimeInterval`.

```csharp
var options = GetInstrumentOptions();
var meter = GetMeter();
var counter = meter.CreateTimedOccurrenceCounter(options, TimeInterval.Milliseconds);

var tags = new TagList();

// Process an action.
counter.Record(() => {}, tags);

// Process a function.
var result = counter.Record(() => System.DateTime.Now, tags);

// Process a function with tags that are dependent on the result.
result = counter.Record(() => System.DateTime.Now, (result) => tags);
```