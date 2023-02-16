using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.University.Requests
{
    public record UniversityUpdate
    {
        [Required]
        public string Name { get; set; }
    }
}
