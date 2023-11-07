namespace Woody230.AspNetCore.Application.Runner;

/// <inheritdoc/>
public sealed class WebApplicationRunner : IWebApplicationRunner
{
    /// <inheritdoc/>
    public void Run(IWebApplication application)
    {
        application.Run();
    }

    /// <inheritdoc/>
    public Task RunAsync(IWebApplication application)
    {
        return application.RunAsync();
    }
}
