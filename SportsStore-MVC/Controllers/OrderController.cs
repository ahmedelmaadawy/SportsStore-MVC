using Microsoft.AspNetCore.Mvc;
using SportsStore_MVC.Models;
using SportsStore_MVC.Repository;

namespace SportsStore_MVC.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repository,Cart cart)
        {
            this.repository = repository;
            this.cart = cart;
        }
        public ViewResult Checkout() => View(new Order());
        
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0) {
                ModelState.AddModelError("", "Sorry, Your Cart is empty");
            }
            if (ModelState.IsValid) { 
                order.Lines = cart.Lines;
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Completed", new {orderId= order.OrderId});
            
            }else
            {
                return View();
            }
        }
    }
}
