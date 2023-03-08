namespace Univent.Api.Contracts.University.Responses
{
    public record UniversityResponse
    {
        public Guid UniversityID { get; set; }
        public string Name { get; set; }
    }
}
