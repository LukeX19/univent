namespace Univent.Api.Contracts.Rating.Responses
{
    public record RatingResponse
    {
        public Guid RatingID { get; set; }
        public Guid UserProfileID { get; set; }
        public double Value { get; set; }
    }
}
