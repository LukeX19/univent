namespace Univent.Api.Contracts.Event.Responses
{
    public record EventResponse
    {
        public Guid EventID { get; private set; }
        public Guid UserProfileID { get; private set; }
        public Guid EventTypeID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int MaximumParticipants { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public bool IsCancelled { get; set; }
        public string? CancellationReason { get; set; }
    }
}
