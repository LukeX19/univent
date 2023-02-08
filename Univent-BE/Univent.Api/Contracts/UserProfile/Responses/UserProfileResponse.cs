using Univent.Domain.Aggregates.EventAggregate;
using Univent.Domain.Aggregates.UniversityAggregate;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Api.Contracts.UserProfile.Responses
{
    public record UserProfileResponse
    {
        public Guid UserID { get; set; }
        public Guid UniversityID { get; set; }
        public University University { get; set; }
        public UniversityYear Year { get; set; }

        private readonly List<Event> _createdEvents = new List<Event>();
        public IEnumerable<Event> CreatedEvents { get { return _createdEvents; } }

        private readonly List<EventParticipant> _participatedEvents = new List<EventParticipant>();
        public IEnumerable<EventParticipant> ParticipatedEvents { get { return _participatedEvents; } }

        private readonly List<Rating> _ratings = new List<Rating>();
        public IEnumerable<Rating> Ratings { get { return _ratings; } }
        public BasicInformation BasicInfo { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
