using Microsoft.AspNetCore.Builder;
using Woody230.AspNetCore.Application;
using Woody230.AspNetCore.Application.Modules;

namespace Woody230.AspNetCore.Web.Modules.Application;

internal class EndpointsModule : IWebApplicationModule
{
    public void Apply(IWebApplication application)
    {
        application.MapControllers();
    }
}
