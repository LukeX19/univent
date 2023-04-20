using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Univent.Dal;

namespace Univent.Api.Registrars
{
    //registrar for database services
    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var connection_string = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection_string));

            builder.Services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<DataContext>();
        }
    }
}
