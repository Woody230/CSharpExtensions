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

var builder = program.Modules.Builder;
builder.Add(new ControllerModule());
builder.Add(new JsonOptionsModule());
builder.Add(new SwaggerGenModule());

var app = program.Modules.Application;
app.Add(new SwaggerUiModule());
app.Add((app) =>
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