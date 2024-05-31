using Microsoft.EntityFrameworkCore;
using SportsStore_MVC.Models;

namespace SportsStore_MVC.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private StoreDbContext context;
        public EFOrderRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Order> orders => context.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            //Attach range notify EF that it shodn't store object unless its modified
            context.AttachRange(order.Lines.Select(l=>l.Product));
            if (order.OrderId == 0) { 
            context.Orders.Add(order);  
            }
            context.SaveChanges();
        }
    }
}
