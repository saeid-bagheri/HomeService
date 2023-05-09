using HomeService.Models.Entities;

namespace HomeService.Repository
{
    public interface IOrderRepository
    {
        List<Order> OrderList();
        void AddOrder(Order order);
        Order GetOrder(int id);
        void RemoveOrder(int id);
        void UpdateOrder(Order order);
    }
}
