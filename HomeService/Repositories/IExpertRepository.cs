using HomeService.Models.Entities;

namespace HomeService.Repositories
{
    public interface IExpertRepository
    {
        void Create(Expert expert);
        List<Expert> GetExperts();
        Expert GetById(int id);
        void Update(Expert expert);
        void DeleteById(int id, int UserId);
    }
}
