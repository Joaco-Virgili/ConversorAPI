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

        public UserDto? GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user is not null)
            {
                return new UserDto()
                {
                    Id = id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    SubscriptionId = user.SubscriptionId
                };
            }
            return null;
        }

        public void Create(CreateOrUpdateUser dto)
        {
            User newUser = new User()
            {
                Email = dto.Email,
                Password = dto.Password,
                Name = dto.Name,
                LastName = dto.LastName,
                SubscriptionId = 1,
                CurrencyConversion = new List<CurrencyConversion>()
            };
            _context.Add(newUser);
            _context.SaveChanges();
        }

        public void Update(CreateOrUpdateUser dto, int Id)
        {
            User userToUpdate = _context.Users.First(u => u.Id == Id);
            userToUpdate.Email = dto.Email;
            userToUpdate.Password = dto.Password;
            _context.SaveChanges();
        }

        public void ChangeSub(ChangeUserSubDto dto, int userId)
        {
            User userSubToChange = _context.Users.First(u => u.Id == userId);
            userSubToChange.SubscriptionId = dto.SubsriptionId;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
            _context.SaveChanges();
        }

        public User? ValidateUser(AuthenticationRequestDto authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }

        public bool CheckIfUserExists(int userId)
        {
            User? user = _context.Users.FirstOrDefault(user => user.Id == userId);
            return user != null;
        }
    }
}
