using SportsStore_MVC.Models;

namespace SportsStore_MVC.Repository
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
