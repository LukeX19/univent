using System.ComponentModel.DataAnnotations;
using Univent.Api.Contracts.ValidationAttributes;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Api.Contracts.UserProfile.Requests
{
    public record UserProfileCreateUpdate
    {
        [Required]
        public Guid UniversityID { get; set; }

        [Required]
        public UniversityYear Year { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [PhoneNumber]
        public string PhoneNumber { get; set; }

        [Required]
        [DateOfBirth]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Hometown { get; set; }

        [Required]
        public string ProfilePicture { get; set; }
    }
}
