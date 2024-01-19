using System.ComponentModel.DataAnnotations;

namespace ConversorAPI.Models.DTO
{
    public class AuthenticationRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
