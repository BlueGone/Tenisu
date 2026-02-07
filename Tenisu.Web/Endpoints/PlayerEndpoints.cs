using Microsoft.AspNetCore.Http.HttpResults;
using Tenisu.Web.Models;

namespace Tenisu.Web.Endpoints;

public static class PlayerEndpoints
{
    public static WebApplication MapPlayerEndpoints(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("/players");

        groupBuilder.MapGet("/", ListPlayersAsync);
        groupBuilder.MapGet("/{id:int}", GetPlayerAsync);

        return app;
    }

    private static Task<IReadOnlyCollection<Player>> ListPlayersAsync() =>
        Task.FromResult<IReadOnlyCollection<Player>>([Player.NovakDjokovic]);

    private static Task<Results<Ok<Player>, NotFound>> GetPlayerAsync(int id)
    {
        if (id == Player.NovakDjokovic.Id)
        {
            return Task.FromResult<Results<Ok<Player>, NotFound>>(
                TypedResults.Ok(Player.NovakDjokovic)
            );
        }

        return Task.FromResult<Results<Ok<Player>, NotFound>>(TypedResults.NotFound());
    }
}
