using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.University.Requests
{
    public record UniversityCreate
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
