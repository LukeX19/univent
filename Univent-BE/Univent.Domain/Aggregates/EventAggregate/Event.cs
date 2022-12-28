using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univent.Domain.Aggregates.UserProfileAggregate;

namespace Univent.Domain.Aggregates.EventAggregate
{
    public class Event
    {
        public Guid EventID { get; private set; }
        public Guid UserID { get; private set; }
        public UserProfile UserProfile { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int MaximumParticipants { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime CreatedDate { get; private set; }

        //Constructor
        private Event()
        {
        }

        //Factory method
        public static Event CreateEvent(Guid userID, string name, string description,
            int maximumParticipants, DateTime startDate, DateTime endDate)
        {
            //TO DO: add validation and error handling
            var createEvent = new Event 
            { 
                UserID= userID,
                Name= name,
                Description= description,
                MaximumParticipants= maximumParticipants,
                StartDate= startDate,
                EndDate= endDate,
                CreatedDate = DateTime.UtcNow
            };

            return createEvent;
        }

        //Public methods
        public void UpdateEvent(string newName, string newDescription, int newMaximumParticipants,
            DateTime newStartDate, DateTime newEndDate)
        {
            Name= newName;
            Description= newDescription;
            MaximumParticipants= newMaximumParticipants;
            StartDate= newStartDate;
            EndDate= newEndDate;
        }
    }
}
