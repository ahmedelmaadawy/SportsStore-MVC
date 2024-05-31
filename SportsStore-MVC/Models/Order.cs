using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SportsStore_MVC.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; } =new List<CartLine>();
        [Required(ErrorMessage ="Please Enter A Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Please Enter The First Address Line")]
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        [Required(ErrorMessage = "Please Enter A city Name")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Please Enter A State Name")]
        public string? State { get; set; }
        public string? Zip { get; set; }
        [Required(ErrorMessage = "Please Enter A Country Name")]
        public string? Country { get; set; }
        public bool GiftWrap { get; set; }


    }
}
