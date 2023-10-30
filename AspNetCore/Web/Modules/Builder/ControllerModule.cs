using Microsoft.Extensions.DependencyInjection;
using Woody230.AspNetCore.Application.Builder;
using Woody230.AspNetCore.Application.Builder.Modules;

namespace Woody230.AspNetCore.Web.Modules.Builder;

internal class ControllerModule : IWebApplicationBuilderModule
{
    public void Apply(IWebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
    }
}
