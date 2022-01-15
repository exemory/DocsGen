using DocsGen.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UniversityContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        string connection = builder.Configuration.GetConnectionString("DefaultConnection");
        options
        .UseNpgsql(connection)
        .EnableSensitiveDataLogging();
    }
    else
    {
        var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        if (databaseUrl == null) throw new Exception("Environment variable DATABASE_URL is null.");

        var databaseUri = new Uri(databaseUrl!);
        var userInfo = databaseUri.UserInfo.Split(':');

        var conStrBuilder = new NpgsqlConnectionStringBuilder
        {
            Host = databaseUri.Host,
            Port = databaseUri.Port,
            Username = userInfo[0],
            Password = userInfo[1],
            Database = databaseUri.LocalPath.TrimStart('/')
        };

        options.UseNpgsql(conStrBuilder.ToString());
    }
});

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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UniversityContext>();

    db.Database.Migrate();
}

app.Run();
