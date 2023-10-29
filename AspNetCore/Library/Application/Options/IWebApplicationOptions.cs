using Woody230.AspNetCore.Program.Arguments;

namespace Woody230.AspNetCore.Application.Options;

/// <summary>
/// The options for creating a web application.
/// </summary>
public interface IWebApplicationOptions
{
    /// <summary>
    /// The command line arguments.
    /// </summary>
    public ICommandLineArguments Arguments { get; }

    /// <summary>
    /// The environment name.
    /// </summary> 
    public string? EnvironmentName { get; }

    /// <summary>
    /// The application name.
    /// </summary>
    public string? ApplicationName { get; }

    /// <summary>
    /// The content root path.
    /// </summary>
    public string? ContentRootPath { get; }

    /// <summary>
    /// The web root path.
    /// </summary>
    public string? WebRootPath { get; }
}
