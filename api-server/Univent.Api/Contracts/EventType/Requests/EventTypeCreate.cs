using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.EventType.Requests
{
    public record EventTypeCreate
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
