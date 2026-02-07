using Tenisu.Web.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPlayerEndpoints();

app.Run();
