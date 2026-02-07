using Tenisu.Application.Handlers.Players;
using Tenisu.Application.Repositories;
using Tenisu.Infrastructure.Repositories;

namespace Tenisu.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<ListPlayersHandler>();
        services.AddScoped<GetPlayerHandler>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPlayersRepository, PlayersRepository>();

        return services;
    }
}
