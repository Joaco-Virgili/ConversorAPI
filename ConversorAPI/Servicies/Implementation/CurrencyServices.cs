using ConversorAPI.Data;
using ConversorAPI.Entites;
using ConversorAPI.Models.DTO;
using ConversorAPI.Servicies.Interfaces;

namespace ConversorAPI.Servicies.Implementation
{
    public class CurrencyServices : ICurrencyServices
    {
        private readonly ConversorDbContext _context;
        public CurrencyServices(ConversorDbContext context) 
        {
            _context = context;
        }

        public List<CurrencyDto> GetAll() 
        {
            return _context.Currencys.Select(c => new CurrencyDto
            {
                Id = c.Id,
                Name = c.Name,
                Symbol = c.Symbol,
                Value = c.Value
            }).ToList();
        }

        public CurrencyDto GetById(int id)
        {
            var currency = _context.Currencys.FirstOrDefault(c => c.Id == id);
            if(currency is not null)
            {
                return new CurrencyDto
                {
                    Id = currency.Id,
                    Name = currency.Name,
                    Symbol = currency.Symbol,
                    Value = currency.Value
                };
            }
            return null;
        }

        public void Create(CreateOrUpdateCurrency dto)
        {
            Currency newCurrency = new Currency()
            {
                Name = dto.Name,
                Symbol = dto.Symbol,
                Value = dto.Value
            };
            _context.Currencys.Add(newCurrency);
            _context.SaveChanges();
        }

        public void Update(CreateOrUpdateCurrency dto, int id)
        {
            Currency currencyToUpdate = _context.Currencys.First(u => u.Id == id);
            currencyToUpdate.Name = dto.Name;
            currencyToUpdate.Symbol = dto.Symbol;
            currencyToUpdate.Value = dto.Value;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            
            Currency? currency = _context.Currencys.FirstOrDefault(u => u.Id == id);
            if (currency != null)
            {
                currency.State = Models.Enum.StateEnum.Inactive;
            }
            _context.SaveChanges();
        }

        public bool CheckIfCurrencyExists(int currencyId)
        {
            Currency? currency = _context.Currencys.FirstOrDefault(c => c.Id == currencyId);
            return currency != null;
        }
    }
}
