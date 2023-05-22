namespace Univent.Api.Contracts.Event.Responses
{
    public record EventResponse
    {
        public Guid EventID { get; set; }
        public Guid UserProfileID { get; set; }
        public Guid EventTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaximumParticipants { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public double LocationLat { get; set; }
        public double LocationLng { get; set; }
        public bool IsCancelled { get; set; }
    }
}
