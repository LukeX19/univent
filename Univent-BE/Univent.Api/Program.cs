using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Univent.Api.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersioning(config => 
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    /* if a client makes a call without specifying version, use default version */
    config.AssumeDefaultVersionWhenUnspecified = true;
    /* responses created will have headers telling the supported API versions */
    config.ReportApiVersions = true;
    config.ApiVersionReader = new UrlSegmentApiVersionReader();
});

/* make swagger work with versioning */
builder.Services.AddVersionedApiExplorer(config => 
{
    config.GroupNameFormat = "'v'VVV";
    config.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach(var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",description.ApiVersion.ToString());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
