using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore_MVC.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        [Required(ErrorMessage ="Please Enter Product Name")]
        public string Name { get; set; } =string.Empty;
        [Required(ErrorMessage = "Please Enter a description")]
        public string Description { get; set; }= string.Empty;
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="Please Enter a positive price")]
        [Column(TypeName ="decimal(8,2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Please Specify a Category")]
        public string Category { get; set; } = string.Empty;
    }
}
