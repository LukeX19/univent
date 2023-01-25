using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Domain.Aggregates.EventAggregate
{
    public class Participants
    {
        public Guid EventID { get; private set; }
        public Event Event { get; private set; }
        public ICollection<UserProfile> ParticipantsOfEvent { get; private set; }

        public void AddParticipant(UserProfile newUser)
        {
            ParticipantsOfEvent.Add(newUser);
        }
    }
}
