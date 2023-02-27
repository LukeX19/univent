using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.Rating.Requests
{
    public record RatingCreate
    {
        public Guid UserProfileID { get; set; }
        public double Value { get; set; }
    }
}
