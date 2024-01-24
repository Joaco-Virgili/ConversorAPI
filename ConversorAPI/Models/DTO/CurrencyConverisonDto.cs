using ConversorAPI.Entites;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorAPI.Models.DTO
{
    public class CurrencyConverisonDto
    {
        public int Id { get; set; }
        public int ToCurrencyId { get; set; }
        public int FromCurrencyId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
    }
}
