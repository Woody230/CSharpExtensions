using System.Threading.Tasks;

namespace Woody230.AspNetCore.App.Application.Runner;

/// <inheritdoc/>
public class WebApplicationRunner : IWebApplicationRunner
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
