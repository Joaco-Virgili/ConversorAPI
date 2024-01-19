using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorAPI.Entites
{
    public class CurrencyConversion
    {
        public int Id { get; set; }
        public int ToCurrencyId { get; set; }
        public Currency ToCurrency { get; set; } = null!;
        public int FromCurrencyId { get; set; }
        public Currency FromCurrency { get; set; } = null!;
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
