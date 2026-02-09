using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tenisu.Application.Handlers.Players;
using Tenisu.Application.Responses.Players;
using Tenisu.Domain.Models;

namespace Tenisu.Web.Endpoints;

public static class PlayerEndpoints
{
    public static WebApplication MapPlayerEndpoints(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("/players");

        groupBuilder.MapGet("/", ListPlayersAsync);
        groupBuilder.MapGet("/{id:int}", GetPlayerAsync);

        groupBuilder.MapPost("/", CreatePlayerAsync);

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

    private static async Task<Results<Ok<Player>, Conflict<ProblemDetails>>> CreatePlayerAsync(
        [FromServices] CreatePlayerHandler handler,
        [FromBody] Player player
    )
    {
        var response = await handler.HandleAsync(player);

        return response switch
        {
            CreatePlayerResponse.Created created => TypedResults.Ok(created.Player),
            CreatePlayerResponse.PlayerWithRankAlreadyExist => TypedResults.Conflict(
                new ProblemDetails { Detail = "Another player with the same rank already exists" }
            ),
            _ => throw new ArgumentOutOfRangeException(response.ToString()),
        };
    }
}
