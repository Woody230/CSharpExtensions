using Microsoft.AspNetCore.Builder;
using System;
using System.Threading.Tasks;
using Woody230.AspNetCore.App.Application;
using Woody230.AspNetCore.App.Application.Runner;
using Woody230.AspNetCore.App.Builder;
using Woody230.AspNetCore.App.Program.Modules;

namespace Woody230.AspNetCore.App.Program;

/// <summary>
/// Creates and builds a <see cref="WebApplication"/> from a <see cref="WebApplicationBuilder"/>.
/// </summary>
public class AspNetCoreWebApplicationProgram : IWebApplicationProgram
{
    private readonly WebApplicationOptions _options;
    private readonly IWebApplicationRunner _applicationRunner;

    public AspNetCoreWebApplicationProgram(WebApplicationOptions options): this(options, new WebApplicationProgramModules(), new WebApplicationRunner())
    {
    }

    public AspNetCoreWebApplicationProgram(WebApplicationOptions options, IWebApplicationProgramModules modules, IWebApplicationRunner applicationRunner)
    {
        _options = options;
        _applicationRunner = applicationRunner;
        Modules = modules;
        Arguments = options.Args ?? Array.Empty<string>();
    }

    public string[] Arguments { get; }

    public IWebApplicationProgramModules Modules { get; }

    public void Run()
    {
        var application = BuildApplication();
        _applicationRunner.Run(application);
    }

    public Task RunAsync()
    {
        var application = BuildApplication();
        return _applicationRunner.RunAsync(application);
    }

    private IWebApplication BuildApplication()
    {
        var builder = new AspNetCoreWebApplicationBuilder(WebApplication.CreateBuilder(_options));
        foreach (var module in Modules.Builder)
        {
            module.Apply(builder);
        }

        var application = builder.Build();
        foreach (var module in Modules.Application)
        {
            module.Apply(application);
        }

        return application;
    }
}
