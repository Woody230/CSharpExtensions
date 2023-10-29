using Woody230.AspNetCore.App.Builder.Application;

namespace Woody230.AspNetCore.App.Modules.Application;

/// <summary>
/// Represents a module that can apply settings to the web application.
/// </summary>
public interface IWebApplicationModule
{
    /// <summary>
    /// Applies settings to the web application.
    /// </summary>
    public void Apply(IWebApplication application);
}
