using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok", service = "gateway" }));

app.MapGet(
    "/health/version",
    () =>
    {
        var v = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0";
        return Results.Ok(new { service = "gateway", version = v });
    }
);

app.Run();
