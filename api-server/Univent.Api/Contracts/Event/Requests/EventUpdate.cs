using System.ComponentModel.DataAnnotations;
using Univent.Api.Contracts.ValidationAttributes;

namespace Univent.Api.Contracts.Event.Requests
{
    public record EventUpdate
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [Range(1, 25)]
        public int MaximumParticipants { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        [EndTimeAfterStartTime]
        public DateTime EndTime { get; set; }
    }
}
