namespace Univent.Api.Contracts.EventParticipant.Requests
{
    public record EventParticipantCreate
    {
        public Guid EventID { get; set; }
    }
}
