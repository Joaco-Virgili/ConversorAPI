using ConversorAPI.Entites;
using ConversorAPI.Models.DTO;

namespace ConversorAPI.Servicies.Interfaces
{
    public interface ISubscriptionServices
    {
        public List<SubscriptionDto> GetAll();
        public SubscriptionDto GetById(int id);
        public void Create(CreateOrUpdateSubs dto);
        public void Update(CreateOrUpdateSubs dto, int id);
        public void Delete(int id);
        public bool CheckIfSubExists(int subId);
    }
}
