using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.University.Requests
{
    public record UniversityCreate
    {
        [Required]
        public string Name { get; set; }
    }
}
