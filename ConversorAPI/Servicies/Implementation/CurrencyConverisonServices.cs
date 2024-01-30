using ConversorAPI.Data;
using ConversorAPI.Entites;
using ConversorAPI.Helpers;
using ConversorAPI.Models.DTO;
using ConversorAPI.Servicies.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConversorAPI.Servicies.Implementation
{
    public class CurrencyConverisonServices : ICurrencyConverisonServices
    {
        private readonly ConversorDbContext _context;
        private readonly CurrencyConversionHelper _currencyConversionHelper;
        public CurrencyConverisonServices(ConversorDbContext context, CurrencyConversionHelper currencyConversionHelper)
        {
            _context = context;
            _currencyConversionHelper = currencyConversionHelper;
        }

        public List<CurrencyConverisonDto> GetAllConversion(int userId)
        {
            return _context.CurrencyConversions.Include(c => c.User).Where(c => c.User.Id == userId).Select(c => new CurrencyConverisonDto
            {
                Id = c.Id,
                ToCurrencyId = c.ToCurrencyId,
                FromCurrencyId = c.FromCurrencyId,
                Amount = c.Amount,
                Result = c.Result,
                UserId = userId,
            }).ToList();
        }

        public CurrencyConversion Create(CreateNewConversionDto dto, int loggedUserId)
        {
            var userSubscription = _context.Users.Where(u => u.Id == loggedUserId).Select(u => u.Subscription).FirstOrDefault();
            var CountOfConversion = _context.CurrencyConversions.Where(u => u.UserId == loggedUserId).Count();


            if (userSubscription != null && userSubscription.AmountOfConversion <= CountOfConversion)
            {
                var toCurrency = _context.Currencys.FirstOrDefault((currency) => currency.Id == dto.ToCurrencyId)!;
                var fromCurrency = _context.Currencys.FirstOrDefault((currency) => currency.Id == dto.FromCurrencyId)!;
                double result;

                if (toCurrency.Value < fromCurrency.Value)
                {
                    result = _currencyConversionHelper.MultiplicateResult(dto.Amount, fromCurrency.Value);
                }
                else
                {
                    result = _currencyConversionHelper.DivideResult(dto.Amount, fromCurrency.Value);
                }

                result = Math.Round(result, 2);

                CurrencyConversion newConversion = new CurrencyConversion()
                {
                    ToCurrencyId = toCurrency.Id,
                    Amount = dto.Amount,
                    FromCurrencyId = fromCurrency.Id,
                    Result = result,
                    UserId = loggedUserId,
                };
                _context.CurrencyConversions.Add(newConversion);
                _context.SaveChanges();
                return newConversion;
            }
            return null;
        }



        public int GetConversionsCount(int userId)
        {
            var CountOfConversion = _context.CurrencyConversions.Where(u => u.UserId == userId).Count();
            return CountOfConversion;
        }
    }
}
