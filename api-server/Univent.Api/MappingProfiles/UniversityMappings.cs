using AutoMapper;
using Univent.Api.Contracts.University.Requests;
using Univent.Api.Contracts.University.Responses;
using Univent.Application.Universities.Commands;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Api.MappingProfiles
{
    public class UniversityMappings : Profile
    {
        public UniversityMappings()
        {
            CreateMap<UniversityCreate, CreateUniversityCommand>();
            CreateMap<UniversityUpdate, UpdateUniversityCommand>();
            CreateMap<University, UniversityResponse>();
        }
    }
}
