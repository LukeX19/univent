namespace Univent.Api.Contracts.Event.Requests
{
    public record EventCreate
    {
        public Guid UserProfileID { get; set; }
        public Guid EventTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaximumParticipants { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
