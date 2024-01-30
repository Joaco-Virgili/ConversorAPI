using ConversorAPI.Entites;
using ConversorAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ConversorAPI.Servicies.Interfaces
{
    public interface ICurrencyConverisonServices
    {
        public List<CurrencyConverisonDto> GetAllConversion(int id);
        public CurrencyConversion Create(CreateNewConversionDto dto, int loggedUserId);
        public int GetConversionsCount(int userId);
    }
}
