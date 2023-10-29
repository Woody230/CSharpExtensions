using Microsoft.Extensions.Logging;

namespace Woody230.AspNetCore.Application.Runner.Logging;

public sealed record LoggingWebApplicationRunnerOptions : ILoggingWebApplicationRunnerOptions
{
    public bool RethrowExceptions { get; set; }
    public LogLevel Level { get; set; } = LogLevel.Error;
}
