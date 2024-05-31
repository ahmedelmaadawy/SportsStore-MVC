using SportsStore_MVC.Infrastructure;
using System.Text.Json.Serialization;

namespace SportsStore_MVC.Models
{
    public class SessionCart :Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession? sessoin = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;
            SessionCart cart = sessoin?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = sessoin;
            return cart;
        }
        [JsonIgnore]
        public ISession? Session { get; set; }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson("Cart",this);
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session?.Remove("Cart");
        }
    }
}
