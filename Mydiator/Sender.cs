using Microsoft.Extensions.DependencyInjection;

namespace Mydiator;

public class Sender(IServiceProvider provider) : ISender
{
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        dynamic handler = provider.GetRequiredService(handlerType);
        if (handler is null)
            throw new InvalidOperationException($"No handler found for {handlerType}!");
        return handler.Handle((dynamic)request, cancellationToken);
    }
}

