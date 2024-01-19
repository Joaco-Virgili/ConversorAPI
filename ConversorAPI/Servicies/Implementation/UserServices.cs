using ConversorAPI.Data;
using ConversorAPI.Entites;
using ConversorAPI.Models.DTO;
using ConversorAPI.Servicies.Interfaces;

namespace ConversorAPI.Servicies.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly ConversorDbContext _context;
        public UserServices(ConversorDbContext context)
        {
            _context = context;
        }

        public List<UserDto> GetAll()
        {
            return _context.Users.Select(u => new UserDto
            { 
                Id = u.Id,
                Name = u.Name,
                LastName = u.LastName,
                Email = u.Email,
                SubscriptionId = u.SubscriptionId
            }).ToList();
        }

        public User? ValidateUser(AuthenticationRequestDto authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }
    }
}
