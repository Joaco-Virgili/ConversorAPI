using System.ComponentModel.DataAnnotations;

namespace ConversorAPI.Models.DTO
{
    public class CreateOrUpdateUser
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
    }
}
