using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Domain.Aggregates.EventAggregate
{
    public class EventParticipant
    {
        public Guid EventID { get; private set; }
        public Guid UserProfileID { get; private set; }
        public Event Event { get; private set; }
        public UserProfile User { get; private set; }
    }
}
