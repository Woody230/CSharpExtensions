namespace Woody230.AspNetCore.Application.Builder.Modules;
internal sealed class DelegatedWebApplicationBuilderModule : IWebApplicationBuilderModule
{
    private readonly Action<IWebApplicationBuilder> _configure;

    public DelegatedWebApplicationBuilderModule(Action<IWebApplicationBuilder> configure)
    {
        _configure = configure;
    }

    public void Apply(IWebApplicationBuilder builder)
    {
        _configure(builder);
    }
}
