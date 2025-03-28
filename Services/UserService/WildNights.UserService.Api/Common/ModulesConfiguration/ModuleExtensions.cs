using WildNights.UserService.Api.Common.Interfaces;

namespace WildNights.UserService.Api.Common.ModulesConfiguration;

public static class ModuleExtensions
{
    private static readonly List<IModule> registeredModules = [];

    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        var modules = DiscoverModules();
        foreach (var module in modules)
        {
            module.RegisterModule(services);
            registeredModules.Add(module);
        }

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (var module in registeredModules)
        {
            module.MapEndpoints(app);
        }
        return app;
    }

    private static IEnumerable<IModule> DiscoverModules()
    {
        var modules = typeof(IModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();

        return modules;
    }
}
