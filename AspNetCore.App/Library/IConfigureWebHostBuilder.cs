using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Infrastructure;

namespace Woody230.AspNetCore.App;

/// <summary>
/// A non-buildable <see cref="IWebHostBuilder"/> for <see cref="WebApplicationBuilder"/>.
/// Use <see cref="WebApplicationBuilder.Build"/> to build the <see cref="WebApplicationBuilder"/>.
/// </summary>
public interface IConfigureWebHostBuilder: IWebHostBuilder, ISupportsStartup
{
}
