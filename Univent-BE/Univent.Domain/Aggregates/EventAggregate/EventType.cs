namespace Univent.Domain.Aggregates.EventAggregate
{
    public class EventType
    {
        public Guid EventTypeID { get; private set; }
        public string Name { get; private set; }
        public ICollection<Event> CreatedEvents { get; private set; }

        //Constructor
        private EventType()
        {
        }

        //Factory method
        public static EventType CreateEventType(string name)
        {
            //TO DO: add validation and error handling
            var newEventType = new EventType
            {
                Name = name
            };

            return newEventType;
        }
    }
}
