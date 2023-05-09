using HomeService.DAL;
using HomeService.Models.Entities;

namespace HomeService.Repositories
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Create(Customer customer)
        {
            _appDbContext.Customers.Add(customer);
            _appDbContext.SaveChanges();
        }

        public void DeleteById(int id, int UserId)
        {
            var currentCustomer = _appDbContext.Customers.FirstOrDefault(c => c.Id == id);
            currentCustomer.IsDeleted = true;
            currentCustomer.DeletedBy = UserId;
            currentCustomer.DeletedAt = DateTime.Now;
            _appDbContext.SaveChanges();
        }

        public Customer GetById(int id)
        {
            return _appDbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> GetCustomers()
        {
            return _appDbContext.Customers.ToList();
        }

        public void Update(Customer customer)
        {
            Customer? currentCustomer = _appDbContext.Customers.Find(customer.Id);
            currentCustomer.FirstName = customer.FirstName;
            currentCustomer.LastName = customer.LastName;
            currentCustomer.Birthdate = customer.Birthdate;
            currentCustomer.MobileNumber = customer.MobileNumber;
            currentCustomer.BackupMobileNumber = customer.BackupMobileNumber;
            currentCustomer.CityId = customer.CityId;
            currentCustomer.LastModifiedAt = DateTime.Now;
            currentCustomer.LastModifiedBy = customer.LastModifiedBy;
            _appDbContext.SaveChanges();
        }
    }
}
