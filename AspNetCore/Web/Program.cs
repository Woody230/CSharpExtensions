using Microsoft.AspNetCore.Builder;
using Woody230.AspNetCore.Application.Modules.Collection;
using Woody230.AspNetCore.Application.Options;
using Woody230.AspNetCore.Program;
using Woody230.AspNetCore.Program.Arguments;
using Woody230.AspNetCore.Web.Modules;
using Woody230.AspNetCore.Web.Modules.Application;
using Woody230.AspNetCore.Web.Modules.Builder;

var arguments = new CommandLineArguments(args);
var options = new AspNetCoreWebApplicationOptions(arguments);
var program = new AspNetCoreWebApplicationProgram(options);

program.Modules.Builder
    .Apply(new ControllerModule())
    .Apply(new JsonOptionsModule())
    .Apply(new SwaggerGenModule());

program.Modules.Application
    .Apply(new SwaggerUiModule())
    .Apply((app) =>
    {
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    });

program.Run();

/// <summary>
/// The program.
/// </summary>
public partial class Program 
{
    // Needed so test project can access the program.
}