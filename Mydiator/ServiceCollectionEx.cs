using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mydiator;

public static class ServiceCollectionEx
{
    public static IServiceCollection AddMydiator(this IServiceCollection services, Assembly? assembly = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        assembly ??= Assembly.GetCallingAssembly();

        services.AddScoped<IMediator, Mediator>();

        var handlerInterfaceType = typeof(IRequestHandler<,>);

        // Protect against ReflectionTypeLoadException and be explicit about classes.
        Type[] types;
        try
        {
            types = assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException ex)
        {
            types = ex.Types.Where(t => t is not null)!.ToArray()!;
        }
        var handlerTypes = types
            .Where(t => t is not null && t.IsClass && !t.IsAbstract)
            .Select(t => new
            {
                Implementation = t!,
                Interfaces = t!.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType)
            })
            .Where(x => x.Interfaces.Any())
            .SelectMany(x => x.Interfaces.Select(i => new { Interface = i, x.Implementation }));

        foreach (var handler in handlerTypes)
            services.AddScoped(handler.Interface, handler.Implementation);
        return services;
    }
}