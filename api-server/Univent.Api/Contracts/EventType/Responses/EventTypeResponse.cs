namespace Univent.Api.Contracts.EventType.Responses
{
    public record EventTypeResponse
    {
        public Guid EventTypeID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}
