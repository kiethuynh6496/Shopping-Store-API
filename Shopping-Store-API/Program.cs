using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Shopping_Store_API.Config;
using Microsoft.AspNetCore.Identity;
using Shopping_Store_API.DBContext;
using Shopping_Store_API.Entities.ERP;
using System;
using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Extensions;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

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
