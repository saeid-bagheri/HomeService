using HomeService.Models.Entities;

namespace HomeService.Repositories
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        List<Customer> GetCustomers();
        Customer GetById(int id);
        void Update(Customer customer);
        void DeleteById(int id, int UserId);
    }
}
