using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univent.Domain.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PictureId { get; set; }
        public IEnumerable<Event> EventsList { get; set; }
    }
}
