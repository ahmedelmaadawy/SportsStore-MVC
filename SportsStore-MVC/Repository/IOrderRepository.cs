using SportsStore_MVC.Models;

namespace SportsStore_MVC.Repository
{
    public interface IOrderRepository
    {
        IQueryable<Order> orders {  get; }
        void SaveOrder(Order order);
    }
}
