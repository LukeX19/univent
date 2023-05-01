using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.EventParticipant.Requests
{
    public record EventParticipantCreate
    {
        [Required]
        public Guid EventID { get; set; }
    }
}
