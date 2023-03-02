namespace Univent.Api.Contracts.Event.Requests
{
    public record EventUpdate_CancelOption
    {
        public string? CancellationReason { get; set; }
    }
}
