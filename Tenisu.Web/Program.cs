using Scalar.AspNetCore;
using Tenisu.Web.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/scalar")).ExcludeFromDescription();
app.MapOpenApi();
app.MapScalarApiReference();

app.MapPlayerEndpoints();

app.Run();
