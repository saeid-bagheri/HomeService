using HomeService.Models.Entities;

namespace HomeService.Repository
{
    public interface ICategoriesRepository
    {
        List<ServiceCategory> ServiceCategoryList();
        void AddServiceCategory(ServiceCategory ServiceCategory);
        bool IsExist(ServiceCategory ServiceCategory);
        ServiceCategory GetServiceCategory(int id);
        void RemoveServiceCategory(int id);
        void UpdateServiceCategory(ServiceCategory ServiceCategory);
    }
}