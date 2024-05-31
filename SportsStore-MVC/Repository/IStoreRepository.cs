using SportsStore_MVC.Models;

namespace SportsStore_MVC.Repository
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct (Product product);
        void DeleteProduct (Product product);
        void CreateProduct (Product product);
    }
}
