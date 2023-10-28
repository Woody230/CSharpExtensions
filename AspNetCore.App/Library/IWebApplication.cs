using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using System;

namespace Woody230.AspNetCore.App;

/// <summary>
/// The web application used to configure the HTTP pipeline, and routes.
/// </summary>
public interface IWebApplication: IHost, IApplicationBuilder, IEndpointRouteBuilder, IAsyncDisposable
{
}
