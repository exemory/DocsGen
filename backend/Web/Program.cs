using Core;
using Core.Exceptions;
using Core.Services;
using Infrastructure;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql;
using Service.Services;
using System.Reflection;
using Web.Conventions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new ControllerDocumentationConvention());
    options.Conventions.Add(new RouteTokenTransformerConvention(new RouteParameterTransformer()));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "DocsGen API"
    });

    options.CustomSchemaIds(type => type.Name.EndsWith("DTO", StringComparison.OrdinalIgnoreCase) ? type.Name[0..^3] : type.Name);

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    options.IncludeXmlComments(xmlFilePath);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IGuarantorService, GuarantorService>();
builder.Services.AddScoped<IHeadOfSmcService, HeadOfSmcService>();
builder.Services.AddScoped<IKnowledgeBranchService, KnowledgeBranchService>();
builder.Services.AddScoped<ISpecialtyService, SpecialtyService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ISyllabusService, SyllabusService>();
builder.Services.AddScoped<ITeacherLoadService, TeacherLoadService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddDbContext<UniversityContext>(options =>
{
    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
    if (databaseUrl == null) throw new EnvironmentException("Environment variable 'DATABASE_URL' is null.");

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

    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DocsGen v1");
    });
}

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
                endpoints.MapFallbackToFile("app/index.html");
            });
    });

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UniversityContext>();

    db.Database.Migrate();
}

app.Run();
