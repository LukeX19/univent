using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Univent.Api.Filters;

namespace Univent.Api.Registrars
{
    public class MvcRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(config =>
            {
                //filter registered globally
                config.Filters.Add(typeof(GeneralExceptionHandler));
            });

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

            builder.Services.AddEndpointsApiExplorer();
        }
    }
}
