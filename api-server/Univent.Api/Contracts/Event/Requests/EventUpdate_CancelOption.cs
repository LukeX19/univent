using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.Event.Requests
{
    public record EventUpdate_CancelOption
    {
        [StringLength(250, MinimumLength = 3)]
        public string? CancellationReason { get; set; }
    }
}
