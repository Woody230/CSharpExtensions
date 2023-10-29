﻿using System.Threading.Tasks;
using Woody230.AspNetCore.App.Program.Arguments;
using Woody230.AspNetCore.App.Program.Modules;

namespace Woody230.AspNetCore.App.Program;

/// <summary>
/// Represents a program for a web application.
/// </summary>
public interface IWebApplicationProgram
{
    /// <summary>
    /// The command line arguments.
    /// </summary>
    public ICommandLineArguments Arguments { get; }

    /// <summary>
    /// The modules for building the program.
    /// </summary>

    public IWebApplicationProgramModules Modules { get; }

    /// <summary>
    /// Runs the program synchronously.
    /// </summary>
    public void Run();

    /// <summary>
    /// Runs the program asynchronously.
    /// </summary>
    public Task RunAsync();
}
