using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.EventParticipant.Requests
{
    public record EventParticipantUpdate_SetFeedback
    {
        [Required]
        public Guid EventID { get; set; }
    }
}
