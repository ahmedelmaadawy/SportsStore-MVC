using Microsoft.AspNetCore.Mvc;
using SportsStore_MVC.Models;
using SportsStore_MVC.Models.ViewModels;
using SportsStore_MVC.Repository;
using System.Diagnostics;

namespace SportsStore_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository _repository;
        public int PageSize = 4;
        public HomeController(IStoreRepository repository)
        {
            _repository = repository;
        }
        public ViewResult Index(int productPage = 1) => View(
            new ProductListViewModel
            {
                Products = _repository.Products
                .OrderBy(p=>p.ProductId)
                .Skip((productPage -1)* PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Products.Count()
                }
            }
            );

    }
}
