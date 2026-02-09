using System.ComponentModel.DataAnnotations;
using Tenisu.Application.Handlers.Players;
using Tenisu.Application.Handlers.Statistic;
using Tenisu.Application.Repositories;
using Tenisu.Domain.Models;
using Tenisu.Infrastructure.Repositories;
using Tenisu.Infrastructure.Seeders;

namespace Tenisu.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<ListPlayersHandler>();
        services.AddScoped<GetPlayerHandler>();
        services.AddScoped<CreatePlayerHandler>();

        services.AddScoped<GetStatisticHandler>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IPlayersRepository, PlayersRepository>();
        services.AddSingleton<IPlayersSeeder, PlayersSeeder>();

        return services;
    }
}
