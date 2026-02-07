using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tenisu.Application.Handlers.Players;
using Tenisu.Domain.Models;

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

    private static Task<IReadOnlyCollection<Player>> ListPlayersAsync(
        [FromServices] ListPlayersHandler handler
    ) => handler.HandleAsync();

    private static async Task<Results<Ok<Player>, NotFound>> GetPlayerAsync(
        [FromServices] GetPlayerHandler handler,
        int id
    )
    {
        var player = await handler.HandleAsync(id);

        if (player is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(player);
    }
}
