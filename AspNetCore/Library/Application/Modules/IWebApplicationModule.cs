namespace Woody230.AspNetCore.Application.Modules;

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
