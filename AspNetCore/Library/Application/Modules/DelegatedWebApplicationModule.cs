namespace Woody230.AspNetCore.Application.Modules;
internal sealed class DelegatedWebApplicationModule : IWebApplicationModule
{
    private readonly Action<IWebApplication> _configure;

    public DelegatedWebApplicationModule(Action<IWebApplication> configure)
    {
        _configure = configure;
    }

    public void Apply(IWebApplication application)
    {
        _configure(application);
    }
}
