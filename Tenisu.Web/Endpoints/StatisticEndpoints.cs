using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tenisu.Application.Handlers.Statistic;
using Tenisu.Domain.Models;

namespace Tenisu.Web.Endpoints;

public static class StatisticEndpoints
{
    public static WebApplication MapStatisticEndpoints(this WebApplication app)
    {
        app.MapGet("/statistic", GetStatisticAsync);

        return app;
    }

    private static async Task<Results<Ok<Statistic>, NoContent>> GetStatisticAsync(
        [FromServices] GetStatisticHandler handler
    )
    {
        var statistic = await handler.HandleAsync();
        if (statistic is null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(statistic);
    }
}
