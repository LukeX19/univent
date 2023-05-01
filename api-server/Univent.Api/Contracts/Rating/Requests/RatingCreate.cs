using System.ComponentModel.DataAnnotations;
using Univent.Api.Contracts.ValidationAttributes;

namespace Univent.Api.Contracts.Rating.Requests
{
    public record RatingCreate
    {
        [Required]
        public Guid UserProfileID { get; set; }

        [Required]
        [RatingCustomDoubleValue]
        public double Value { get; set; }
    }
}
