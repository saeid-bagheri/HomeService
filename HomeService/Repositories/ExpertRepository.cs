using HomeService.DAL;
using HomeService.Models.Entities;

namespace HomeService.Repositories
{
    public class ExpertRepository : IExpertRepository
    {
        private readonly AppDbContext _appDbContext;

        public ExpertRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Create(Expert expert)
        {
            _appDbContext.Experts.Add(expert);
            _appDbContext.SaveChanges();
        }

        public void DeleteById(int id, int UserId)
        {
            var currentExpert = _appDbContext.Experts.FirstOrDefault(c => c.Id == id);
            currentExpert.IsDeleted = true;
            currentExpert.DeletedBy = UserId;
            currentExpert.DeletedAt = DateTime.Now;
            _appDbContext.SaveChanges();
        }

        public Expert GetById(int id)
        {
            return _appDbContext.Experts.FirstOrDefault(e => e.Id == id);
        }

        public List<Expert> GetExperts()
        {
            return _appDbContext.Experts.ToList();
        }

        public void Update(Expert expert)
        {
            var currentExpert = _appDbContext.Experts.FirstOrDefault(e => e.Id ==  expert.Id);
            currentExpert.FirstName = expert.FirstName;
            currentExpert.LastName = expert.LastName;
            currentExpert.MobileNumber = expert.MobileNumber;
            currentExpert.BackupMobileNumber = expert.BackupMobileNumber;
            currentExpert.Birthdate = expert.Birthdate;
            currentExpert.City = expert.City;
            currentExpert.CompanyName = expert.CompanyName;
            currentExpert.HomeAddress = expert.HomeAddress;
            currentExpert.LastModifiedAt = DateTime.Now;
            currentExpert.LastModifiedBy = expert.LastModifiedBy;
            _appDbContext.SaveChanges();
        }
    }
}
