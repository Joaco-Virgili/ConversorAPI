using ConversorAPI.Entites;
using ConversorAPI.Models.DTO;

namespace ConversorAPI.Servicies.Interfaces
{
    public interface IUserServices
    {
        public List<UserDto> GetAll();
        public User? ValidateUser(AuthenticationRequestDto authRequestBody);
    }
}
