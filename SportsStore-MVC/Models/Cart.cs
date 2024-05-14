namespace SportsStore_MVC.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public void AddItem(Product product,int quantity)
        {
            CartLine? line = Lines
        }
    }

    public class CartLine
    {
        public int CartLneID { get; set; }

    }
}
