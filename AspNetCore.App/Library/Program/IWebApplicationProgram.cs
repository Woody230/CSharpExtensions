using System.Threading.Tasks;
using Woody230.AspNetCore.App.Program.Modules;

namespace Woody230.AspNetCore.App.Program;
public interface IWebApplicationProgram
{
    public string[] Arguments { get; }

    public IWebApplicationProgramModules Modules { get; }

    public void Run();
    public Task RunAsync();
}
