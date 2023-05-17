using AutoMapper;
using Univent.Api.Contracts.Rating.Requests;
using Univent.Api.Contracts.Rating.Responses;
using Univent.Application.Ratings.Commands;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Api.MappingProfiles
{
    public class RatingMappings : Profile
    {
        public RatingMappings()
        {
            CreateMap<RatingCreate, CreateRatingCommand>();
            CreateMap<Rating, RatingResponse>();
            CreateMap<double, AverageRatingResponse>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));
        }
    }
}
