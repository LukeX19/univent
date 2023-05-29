using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.EventType.Requests
{
    public record EventTypeUpdate
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Picture { get; set; }
    }
}
