using Microsoft.Extensions.DependencyInjection;
using minMediator.domain;

namespace minMediator.services;

public static class Extensions
{
    public static IServiceCollection AddMinMediatorServices(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<PingRequest, Result<string>>, PingHandler>();
        return services;
    }
}
