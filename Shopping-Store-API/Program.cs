using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;
using Shopping_Store_API.Extensions;

try
{
    Log.Information("Starting web host");

    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog();

    builder.Services
            .AddDatabase(builder.Configuration)
            .AddRepositories()
            .AddServices();

    var app = builder.Build();
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    // Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
        options.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    });
    app.UseIpRateLimiting();
    app.ConfigureAPIApp();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}