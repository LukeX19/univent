using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Univent.Api.Middleware;

namespace Univent.Api.Registrars
{
    public class MvcWebApplicationRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            //Exception Middleware
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.ApiVersion.ToString());
                }
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
