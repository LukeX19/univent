using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univent.Domain.Models
{
    public class Event
    {
        public int Id { get; set; }
        //public string nameofevent { get; set; }
        //public int maximumparticipants { get; set; }
        //public datetime startdatetime { get; set; }
        //public datetime enddatetime { get; set; }
        public string Description { get; set; }
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
    }
}
