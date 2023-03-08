using MediatR;
using Univent.Application.UserProfiles.Queries;

namespace Univent.Api.Registrars
{
    //this registrar is named after the author of AutoMapper and MediatR
    public class BogardRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            //GetAllUserProfiles argument was chosen randomly, the purpose is just to make the builder scan the Application layer
            builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllUserProfiles));
            builder.Services.AddMediatR(typeof(GetAllUserProfiles));
        }
    }
}
