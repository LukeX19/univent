using AutoMapper;
using Univent.Api.Contracts.UserProfile.Requests;
using Univent.Api.Contracts.UserProfile.Responses;
using Univent.Application.UserProfiles.Commands;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Api.MappingProfiles
{
    public class UserProfileMappings : Profile
    {
        public UserProfileMappings()
        {
            CreateMap<UserProfileCreateUpdate, CreateUserCommand>();
            CreateMap<UserProfileCreateUpdate, UpdateUserProfileBasicInformationCommand>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<BasicInformation, BasicInfo>();
        }
    }
}
