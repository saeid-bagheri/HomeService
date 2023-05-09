using HomeService.DAL;
using HomeService.Models.Entities;

namespace HomeService.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoriesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<ServiceCategory> ServiceCategoryList()
        {
            var category = _appDbContext.ServiceCategories.ToList();
            return category;

        }
        public void AddServiceCategory(ServiceCategory category)
        {
            if (!IsExist(category))
            {
                _appDbContext.ServiceCategories.Add(category);
                _appDbContext.SaveChanges();
            }
        }
        public bool IsExist(ServiceCategory category)
        {
            var result = _appDbContext.ServiceCategories.Any(c => c.Title == category.Title);
            return result;
        }
        public ServiceCategory GetServiceCategory(int id)
        {
            return _appDbContext.ServiceCategories.FirstOrDefault(c =>c.Id == id);
        }
        public void RemoveServiceCategory(int id)
        {
            var CategoryRow = _appDbContext.ServiceCategories.FirstOrDefault(x => x.Id == id);
            _appDbContext.ServiceCategories.Remove(CategoryRow);
            _appDbContext.SaveChanges();
            
        }
        public void UpdateServiceCategory(ServiceCategory category)
        {
            var CategoryRow = _appDbContext.ServiceCategories.FirstOrDefault(x => x.Id == category.Id);
            CategoryRow.Title = category.Title;
            CategoryRow.ParentId = category.ParentId;
            _appDbContext.SaveChanges();

        }
    }
}
