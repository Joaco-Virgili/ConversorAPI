using ConversorAPI.Data;
using ConversorAPI.Entites;
using ConversorAPI.Models.DTO;
using ConversorAPI.Servicies.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConversorAPI.Servicies.Implementation
{
    public class CurrencyConverisonServices : ICurrencyConverisonServices
    {
        private readonly ConversorDbContext _context;
        public CurrencyConverisonServices(ConversorDbContext context)
        {
            _context = context;
        }

        public List<CurrencyConverisonDto> GetAllConversion(int userId)
        {
            return _context.CurrencyConversions.Include(c => c.User).Where(c => c.User.Id == userId).Select(c => new CurrencyConverisonDto
            {
                Id = c.Id,
                ToCurrencyId = c.ToCurrencyId,
                FromCurrencyId = c.FromCurrencyId,
                Amount = c.Amount,
                Date = c.Date,
                UserId = userId,
            }).ToList();
        }
    }
}
