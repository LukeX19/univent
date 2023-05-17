using AutoMapper;
using Univent.Api.Contracts.Identity;
using Univent.Application.Identity.Commands;

namespace Univent.Api.MappingProfiles
{
    public class IdentityMappings : Profile
    {
        public IdentityMappings()
        {
            CreateMap<UserRegistration, RegisterIdentityCommand>();
            CreateMap<Login, LoginCommand>();
            CreateMap<ChangePassword, ChangePasswordCommand>();
        }
    }
}
