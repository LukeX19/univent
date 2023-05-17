using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.Identity
{
    public class ChangePassword
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
