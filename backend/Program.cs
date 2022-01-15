var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseWhen(
    context => context.Request.Path.StartsWithSegments("/api"),
    app =>
    {
        app.UseRouting();
        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();
            });
    });

app.UseWhen(
    context => !context.Request.Path.StartsWithSegments("/api"),
    app =>
    {
        app.UseStaticFiles();
        app.UseRouting();
        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapFallbackToFile("index.html");
            });
    });

app.Run();
