using Microsoft.AspNetCore.Builder;
using System.Linq;
using System.Threading.Tasks;
using Woody230.AspNetCore.Application;
using Woody230.AspNetCore.Application.Builder;
using Woody230.AspNetCore.Application.Options;
using Woody230.AspNetCore.Application.Runner;
using Woody230.AspNetCore.Program.Arguments;
using Woody230.AspNetCore.Program.Modules;

namespace Woody230.AspNetCore.Program;

/// <summary>
/// Creates and builds a <see cref="WebApplication"/> from a <see cref="WebApplicationBuilder"/>.
/// </summary>
public sealed class AspNetCoreWebApplicationProgram : IWebApplicationProgram
{
    private readonly IWebApplicationOptions _applicationOptions;
    private readonly IWebApplicationRunner _applicationRunner;

    public AspNetCoreWebApplicationProgram(IWebApplicationOptions applicationOptions): this(applicationOptions, new WebApplicationProgramModules(), new WebApplicationRunner())
    {
    }

    public AspNetCoreWebApplicationProgram(IWebApplicationOptions applicationOptions, IWebApplicationProgramModules modules, IWebApplicationRunner applicationRunner)
    {
        _applicationOptions = applicationOptions;
        _applicationRunner = applicationRunner;
        Modules = modules;
        Arguments = applicationOptions.Arguments;
    }

    public ICommandLineArguments Arguments { get; }

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
        var options = new WebApplicationOptions()
        {
            ApplicationName = _applicationOptions.ApplicationName,
            Args = _applicationOptions.Arguments.ToArray(),
            ContentRootPath = _applicationOptions.ContentRootPath,
            EnvironmentName = _applicationOptions.EnvironmentName,
            WebRootPath = _applicationOptions.WebRootPath
        };

        var builder = new AspNetCoreWebApplicationBuilder(WebApplication.CreateBuilder(options));
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
