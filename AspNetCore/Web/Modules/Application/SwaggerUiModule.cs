using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Woody230.AspNetCore.Application;
using Woody230.AspNetCore.Application.Modules;

namespace Woody230.AspNetCore.Web.Modules.Application;

internal class SwaggerUiModule : IWebApplicationModule
{
    public void Apply(IWebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
