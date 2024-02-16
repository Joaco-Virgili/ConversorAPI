using ConversorAPI.Entites;
using ConversorAPI.Models.DTO;

namespace ConversorAPI.Servicies.Interfaces
{
    public interface IUserServices
    {
        public List<UserDto> GetAll();
        public UserDto GetById(int id);
        public void Create(CreateOrUpdateUser dto);
        public void Update(CreateOrUpdateUser dto, int Id);
        public void ChangeSub (ChangeUserSubDto dto, int userId);
        public void Delete(int id);
        public int GetAmountOfConversion(int id);
        public User? ValidateUser(AuthenticationRequestDto authRequestBody);
        public bool CheckIfUserExists(int userId);
    }
}
