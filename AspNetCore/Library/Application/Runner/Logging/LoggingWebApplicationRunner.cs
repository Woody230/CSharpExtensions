using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Woody230.AspNetCore.Application.Runner.Logging;

/// <summary>
/// Decorates a <see cref="IWebApplicationRunner"/> with the ability to catch and log exceptions, and rethrows the exception.
/// </summary>
public sealed class LoggingWebApplicationRunner : IWebApplicationRunner
{
    private readonly IWebApplicationRunner _applicationRunner;
    private readonly ILogger<IWebApplicationRunner> _logger;
    private readonly ILoggingWebApplicationRunnerOptions _options;

    public LoggingWebApplicationRunner(IWebApplicationRunner applicationRunner, ILogger<IWebApplicationRunner> logger): this(applicationRunner, logger, new LoggingWebApplicationRunnerOptions())
    {
    }

    public LoggingWebApplicationRunner(IWebApplicationRunner applicationRunner, ILogger<IWebApplicationRunner> logger, ILoggingWebApplicationRunnerOptions options)
    {
        _applicationRunner = applicationRunner;
        _logger = logger;
        _options = options;
    }

    public void Run(IWebApplication application)
    {
        try
        {
            _applicationRunner.Run(application);
        }
        catch (Exception ex)
        {
            LogException(ex);

            if (_options.RethrowExceptions)
            {
                throw;
            }
        }
    }

    public Task RunAsync(IWebApplication application)
    {
        try
        {
            return _applicationRunner.RunAsync(application);
        }
        catch (Exception ex)
        {
            LogException(ex);

            if (_options.RethrowExceptions)
            {
                throw;
            }
            else
            {
                return Task.CompletedTask;
            }
        }
    }

    private void LogException(Exception ex)
    {
        _logger.Log(_options.Level, ex, "Failed to run the application.");
    }
}
