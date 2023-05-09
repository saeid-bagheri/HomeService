using HomeService.DAL;
using HomeService.Models.Entities;
using System;

namespace HomeService.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddOrder(Order order)
        {
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }

        public Order GetOrder(int id)
        {
            return _appDbContext.Orders.FirstOrDefault(c => c.Id == id);
        }



        public List<Order> OrderList()
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
