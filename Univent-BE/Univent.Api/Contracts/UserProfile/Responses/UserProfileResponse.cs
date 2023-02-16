using Univent.Domain.Aggregates.EventAggregate;
using Univent.Domain.Aggregates.UniversityAggregate;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Api.Contracts.UserProfile.Responses
{
    public record UserProfileResponse
    {
        public Guid UserID { get; set; }
        public Guid UniversityID { get; set; }
        public UniversityYear Year { get; set; }
        public BasicInformation BasicInfo { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
