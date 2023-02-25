using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Domain.Aggregates.EventAggregate
{
    public class Event
    {
        public Guid EventID { get; private set; }
        public Guid UserProfileID { get; private set; }
        public Guid EventTypeID { get; private set; }
        public UserProfile UserHost { get; private set; }
        public EventType EventType { get; private set; }

        private readonly List<EventParticipant> _participants = new List<EventParticipant>();
        public IEnumerable<EventParticipant> Participants { get { return _participants; } }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int MaximumParticipants { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsCancelled { get; private set; }
        public string? CancellationReason { get; private set; }

        //Constructor
        private Event()
        {
        }

        //Factory method
        public static Event CreateEvent(Guid userID, string name, string description,
            int maximumParticipants, DateTime startTime, DateTime endTime)
        {
            //TO DO: add validation and error handling
            var newEvent = new Event 
            { 
                UserProfileID = userID,
                Name = name,
                Description = description,
                MaximumParticipants = maximumParticipants,
                StartTime = startTime,
                EndTime = endTime,
                CreatedDate = DateTime.UtcNow,
                IsCancelled = false
            };

            return newEvent;
        }

        //Public methods
        public void UpdateEvent(string newName, string newDescription, int newMaximumParticipants,
            DateTime newStartTime, DateTime newEndTime)
        {
            Name = newName;
            Description = newDescription;
            MaximumParticipants = newMaximumParticipants;
            StartTime = newStartTime;
            EndTime = newEndTime;
        }

        public void AddParticipant(EventParticipant newUser)
        {
            _participants.Add(newUser);
        }

        public void RemoveParticipant(EventParticipant toRemoveParticipant)
        {
            _participants.Remove(toRemoveParticipant);
        }
    }
}
