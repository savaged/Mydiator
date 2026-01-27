using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mydiator;

public static class ServiceCollectionEx
{
    public static IServiceCollection AddMyMediator(this IServiceCollection services, Assembly? assembly = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        assembly ??= Assembly.GetCallingAssembly();

        services.AddScoped<ISender, Sender>();

        var handlerInterfaceType = typeof(IRequestHandler<,>);

        var handlerTypes = assembly
            .GetTypes()
            .Where(type => !type.IsAbstract && !type.IsInterface)
            .SelectMany(type => type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType)
                .Select(i => new { Interface = i, Implementation = type }));

        foreach (var handler in handlerTypes)
            services.AddScoped(handler.Interface, handler.Implementation);
        return services;
    }
}

