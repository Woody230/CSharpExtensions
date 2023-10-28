using Microsoft.AspNetCore.Hosting.Infrastructure;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woody230.AspNetCore.App;

/// <summary>
/// A non-buildable <see cref="IHostBuilder"/> for <see cref="WebApplicationBuilder"/>.
/// Use <see cref="WebApplicationBuilder.Build"/> to build the <see cref="WebApplicationBuilder"/>.
/// </summary>
public interface IConfigureHostBuilder: IHostBuilder, ISupportsConfigureWebHost
{
}
