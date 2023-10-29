using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Woody230.AspNetCore.Application.Runner;

/// <summary>
/// Decorates a <see cref="IWebApplicationRunner"/> with the ability to catch and log exceptions, and rethrows the exception.
/// </summary>
public sealed class LoggingWebApplicationRunner : IWebApplicationRunner
{
    private readonly IWebApplicationRunner _applicationRunner;
    private readonly ILogger<IWebApplicationRunner> _logger;

    public LoggingWebApplicationRunner(IWebApplicationRunner applicationRunner, ILogger<IWebApplicationRunner> logger)
    {
        _applicationRunner = applicationRunner;
        _logger = logger;
    }

    public void Run(IWebApplication application)
    {
        try
        {
            _applicationRunner.Run(application);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to run the application.");
            throw;
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
            _logger.LogError(ex, "Failed to run the application.");
            throw;
        }
    }
}
