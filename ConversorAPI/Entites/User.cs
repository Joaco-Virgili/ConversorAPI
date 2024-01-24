using ConversorAPI.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorAPI.Entites
{
    public class User
    {
        public int Id { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public RoleEnum Role { get; set; } = RoleEnum.User;
        public List<CurrencyConversion> CurrencyConversion { get; set; }
        [ForeignKey("SubscriptionId")]
        public int SubscriptionId { get; set; } = 1;
        public Subscription Subscription { get; set; }
    }
}
