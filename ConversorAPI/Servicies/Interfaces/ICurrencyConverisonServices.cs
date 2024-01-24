using ConversorAPI.Models.DTO;

namespace ConversorAPI.Servicies.Interfaces
{
    public interface ICurrencyConverisonServices
    {
        public List<CurrencyConverisonDto> GetAllConversion(int id);
    }
}
