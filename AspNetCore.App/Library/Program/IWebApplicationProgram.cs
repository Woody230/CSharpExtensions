using System.Threading.Tasks;

namespace Woody230.AspNetCore.App.Program;
public interface IWebApplicationProgram
{
    public string[] Arguments { get; }

    public IWebApplicationProgramModules Modules { get; }

    public void Run();
    public Task RunAsync();
}
