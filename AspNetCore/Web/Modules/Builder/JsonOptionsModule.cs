using System.Text.Json.Serialization;
using Woody230.AspNetCore.Application.Builder;
using Woody230.AspNetCore.Application.Builder.Modules;

namespace Woody230.AspNetCore.Web.Modules;

internal class JsonOptionsModule : IWebApplicationBuilderModule
{
    public void Apply(IWebApplicationBuilder builder)
    {
        builder.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
    }
}
