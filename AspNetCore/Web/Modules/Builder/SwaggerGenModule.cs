using System.Reflection;
using Woody230.AspNetCore.Application.Builder;
using Woody230.AspNetCore.Application.Builder.Modules;

namespace Woody230.AspNetCore.Web.Modules.Builder;

internal class SwaggerGenModule : IWebApplicationBuilderModule
{
    public void Apply(IWebApplicationBuilder builder) => builder.Services.AddSwaggerGen(options =>
    {
        var name = Assembly.GetExecutingAssembly().GetName().Name;
        var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{name}.xml");
        options.IncludeXmlComments(xmlPath);
    });
}
