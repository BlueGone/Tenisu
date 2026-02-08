using Scalar.AspNetCore;
using Tenisu.Web;
using Tenisu.Web.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories();
builder.Services.AddHandlers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/scalar")).ExcludeFromDescription();
app.MapOpenApi();
app.MapScalarApiReference();

app.MapPlayerEndpoints();
app.MapStatisticEndpoints();

app.Run();
