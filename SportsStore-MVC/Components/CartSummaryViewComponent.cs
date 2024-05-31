using Microsoft.AspNetCore.Mvc;
using SportsStore_MVC.Models;

namespace SportsStore_MVC.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private Cart Cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            Cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(Cart);  
        }
    }
}
