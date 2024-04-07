using System.Diagnostics;
using System.Diagnostics.Metrics;
using Woody230.Diagnostics.Metrics;

namespace Woody230.Diagnostics.Tests.Metrics.Instruments;
public abstract class InstrumentTests
{
    protected Meter Meter { get; } = new("woody230.metrics");
    protected Guid Id { get; } = new("2f3c8e5e-8f3f-4daa-941c-80d390684d5a");
    protected TagList Tags { get; }
    protected InstrumentOptions Options { get; }

    public InstrumentTests()
    {
        Tags = new TagList().With("woody230.id", Id);
        Options = new("woody230.entity")
        {
            Description = "processing entity",
            Tags = Tags,
        };
    }
}
