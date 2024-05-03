using SportsStore_MVC.Models;

namespace SportsStore_MVC.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _Context;
        public StoreRepository(StoreDbContext context)
        {
            _Context = context;
        }
        public IQueryable<Product> Products => _Context.Products;
    }
}
