﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Infrastructure;

namespace Woody230.AspNetCore.App;

/// <summary>
/// A non-buildable <see cref="IWebHostBuilder"/> for <see cref="IWebApplicationBuilder"/>.
/// Use <see cref="IWebApplicationBuilder.Build"/> to build the <see cref="IWebApplicationBuilder"/>.
/// </summary>
public interface IConfigureWebHostBuilder: IWebHostBuilder, ISupportsStartup
{
}
