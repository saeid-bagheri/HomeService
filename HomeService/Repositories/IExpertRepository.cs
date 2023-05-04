using HomeService.Models.Entities;

namespace HomeService.Repositories
{
    public interface IExpertRepository
    {
        void Create(Expert expert);
        List<Expert> GetCustomers();
        Customer GetById(int id);
        void Update(Expert expert);
        void DeleteById(int id, int deletedByUserId);
        //void
    }
}
