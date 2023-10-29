using Microsoft.Extensions.Logging;

namespace Woody230.AspNetCore.Application.Runner.Logging;

/// <summary>
/// Represents the options for the <see cref="LoggingWebApplicationRunner"/>
/// </summary>
public interface ILoggingWebApplicationRunnerOptions
{
    /// <summary>
    /// Whether exceptions should be rethrown.
    /// </summary>
    public bool RethrowExceptions { get; }

    /// <summary>
    /// The level to log the exceptions.
    /// </summary>
    public LogLevel Level { get; }
}
