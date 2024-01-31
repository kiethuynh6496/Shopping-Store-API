using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Shopping_Store_API.Extensions;


var builder = WebApplication.CreateBuilder(args);

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
});

app.ConfigureAPIApp();

app.Run();
