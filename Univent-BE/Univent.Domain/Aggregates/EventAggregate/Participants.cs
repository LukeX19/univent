using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Domain.Aggregates.EventAggregate
{
    public class Participants
    {
        public Guid EventID { get; private set; }
        public Event Event { get; private set; }
        private readonly List<UserProfile> _participants = new List<UserProfile>();
        public IEnumerable<UserProfile> ParticipantsOfEvent { get { return _participants; } }

        public void AddParticipant(UserProfile newUser)
        {
            _participants.Add(newUser);
        }
    }
}
