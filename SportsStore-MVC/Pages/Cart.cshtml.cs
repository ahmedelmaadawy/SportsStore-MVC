using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore_MVC.Infrastructure;
using SportsStore_MVC.Models;
using SportsStore_MVC.Repository;

namespace SportsStore_MVC.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;
        public CartModel(IStoreRepository repository ,Cart cartService)
        {
            this.repository = repository;
            this.Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();

        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product? product = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                Cart.AddItem(product, 1);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long productId, string returnUrl) {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId == productId).Product);
            return RedirectToPage(new {returnUrl = returnUrl});
        
        }
    }
}
