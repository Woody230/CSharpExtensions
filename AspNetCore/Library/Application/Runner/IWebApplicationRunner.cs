using System.Threading.Tasks;

namespace Woody230.AspNetCore.Application.Runner;

/// <summary>
/// Runs a <see cref="IWebApplication"/>.
/// </summary>
public interface IWebApplicationRunner
{
    /// <summary>
    /// Runs the application synchronously.
    /// </summary>
    public void Run(IWebApplication application);

    /// <summary>
    /// Runs the application asynchronously.
    /// </summary>
    public Task RunAsync(IWebApplication application);
}
