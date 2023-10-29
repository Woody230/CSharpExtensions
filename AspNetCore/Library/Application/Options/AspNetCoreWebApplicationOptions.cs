using Microsoft.AspNetCore.Builder;
using System;
using Woody230.AspNetCore.Program.Arguments;

namespace Woody230.AspNetCore.Application.Options;
public sealed class AspNetCoreWebApplicationOptions : IWebApplicationOptions
{
    public AspNetCoreWebApplicationOptions(ICommandLineArguments arguments)
    {
        Arguments = arguments;
    }

    public AspNetCoreWebApplicationOptions(WebApplicationOptions options)
    {
        Arguments = new CommandLineArguments(options.Args ?? Array.Empty<string>());
        EnvironmentName = options.EnvironmentName;
        ApplicationName = options.ApplicationName;
        ContentRootPath = options.ContentRootPath;
        WebRootPath = options.WebRootPath;
    }

    public ICommandLineArguments Arguments { get; }

    public string? EnvironmentName { get; }

    public string? ApplicationName { get; }

    public string? ContentRootPath { get; }

    public string? WebRootPath { get; }
}
