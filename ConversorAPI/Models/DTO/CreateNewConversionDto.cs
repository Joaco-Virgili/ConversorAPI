namespace ConversorAPI.Models.DTO
{
    public class CreateNewConversionDto
    {
        public int ToCurrencyId { get; set; }
        public int FromCurrencyId { get; set; }
        public double Amount { get; set; }
    }
}
