using System.ComponentModel.DataAnnotations;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Api.Contracts.Identity
{
    public class UserRegistration
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Guid UniversityID { get; set; }

        [Required]
        public UniversityYear Year { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Hometown { get; set; }
    }
}
