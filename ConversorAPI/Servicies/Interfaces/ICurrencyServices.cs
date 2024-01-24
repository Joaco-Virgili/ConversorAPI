using ConversorAPI.Models.DTO;

namespace ConversorAPI.Servicies.Interfaces
{
    public interface ICurrencyServices
    {
        public List<CurrencyDto> GetAll();
        public CurrencyDto? GetById(int id);
        public void Create(CreateOrUpdateCurrency dto);
        public void Update(CreateOrUpdateCurrency dto, int id);
        public void Delete(int id);
        public bool CheckIfCurrencyExists(int currencyId);
    }
}
