using ConversorAPI.Models.Enum;

namespace ConversorAPI.Models.DTO
{
    public class CurrencyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Value { get; set; }
        public StateEnum State { get; set; }
    }
}
