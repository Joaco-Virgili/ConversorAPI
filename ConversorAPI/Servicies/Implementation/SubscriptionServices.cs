using ConversorAPI.Data;
using ConversorAPI.Entites;
using ConversorAPI.Models.DTO;
using ConversorAPI.Servicies.Interfaces;

namespace ConversorAPI.Servicies.Implementation
{
    public class SubscriptionServices : ISubscriptionServices
    {
        private readonly ConversorDbContext _context;
        public SubscriptionServices(ConversorDbContext context)
        {
            _context = context;
        }

        public List<SubscriptionDto> GetAll()
        {
            return _context.Subscriptions.Select(s => new SubscriptionDto
            {
                Id = s.Id,
                Name = s.Name,
                AmountOfConversion = s.AmountOfConversion,
                Price = s.Price
            }).ToList();
        }

        public SubscriptionDto GetById(int id)
        {
            var sub = _context.Subscriptions.FirstOrDefault(s => s.Id == id);
            if (sub is not null)
            {
                return new SubscriptionDto()
                {
                    Id = sub.Id,
                    Name = sub.Name,
                    AmountOfConversion = sub.AmountOfConversion,
                    Price = sub.Price
                };
            }
            return null;
        }

        public void Create(CreateOrUpdateSubs dto)
        {
            Subscription newSub = new Subscription()
            {
                Name = dto.Name,
                AmountOfConversion = dto.AmountofConversion,
                Price = dto.Price
            };
            _context.Subscriptions.Add(newSub);
            _context.SaveChanges();
        }

        public void Update(CreateOrUpdateSubs dto, int id)
        {
            Subscription subToUpdate = _context.Subscriptions.First(u => u.Id == id);
            subToUpdate.Name = dto.Name;
            subToUpdate.AmountOfConversion = dto.AmountofConversion;
            subToUpdate.Price = dto.Price;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Subscription? sub = _context.Subscriptions.FirstOrDefault(u => u.Id == id);
            if (sub != null)
            {
                sub.State = Models.Enum.StateEnum.Inactive;
            }
            _context.SaveChanges();
        }

        public bool CheckIfSubExists(int subId)
        {
            Subscription? sub = _context.Subscriptions.FirstOrDefault(c => c.Id == subId);
            return sub != null;
        }
    }
}
