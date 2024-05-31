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

        public void CreateProduct(Product product)
        {
            _Context.Add(product);
            _Context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _Context.Remove(product);
            _Context.SaveChanges();

        }

        public void SaveProduct(Product product)
        {
            _Context.SaveChanges();
        }
    }
}
