namespace Woody230.AspNetCore.Application.Builder.Modules;

/// <summary>
/// Represents a module that can apply settings to the web application builder.
/// </summary>
public interface IWebApplicationBuilderModule
{
    /// <summary>
    /// Applies settings to the web application builder.
    /// </summary>
    public void Apply(IWebApplicationBuilder builder);
}
