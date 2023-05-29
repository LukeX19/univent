namespace Univent.Domain.Aggregates.EventAggregate
{
    public class EventType
    {
        public Guid EventTypeID { get; private set; }
        public string Name { get; private set; }
        public string Picture { get; private set; }

        private readonly List<Event> _events = new List<Event>();
        public IEnumerable<Event> Events { get { return _events; } }

        //Constructor
        private EventType()
        {
        }

        //Factory method
        public static EventType CreateEventType(string name, string picture)
        {
            //TO DO: add validation and error handling
            var newEventType = new EventType
            {
                Name = name,
                Picture = picture
            };

            return newEventType;
        }

        //Public methods start here
        public void UpdateEventType(string newName, string newPicture)
        {
            Name = newName;
            Picture = newPicture;
        }
    }
}
