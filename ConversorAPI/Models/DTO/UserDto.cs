using System.ComponentModel.DataAnnotations;

namespace ConversorAPI.Models.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int SubscriptionId { get; set; }
    }
}
