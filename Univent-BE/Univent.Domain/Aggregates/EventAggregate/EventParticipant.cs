using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Domain.Aggregates.EventAggregate
{
    public class EventParticipant
    {
        [Key]
        [Column(Order = 0)]
        public Guid EventID { get; private set; }

        [Key]
        [Column(Order = 1)]
        public Guid UserID { get; private set; }
        public Event Event { get; private set; }
        public UserProfile User { get; private set; }
    }
}
