using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Core.ViewModels.Products
{
    public class ProductsVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? TimeDeleted { get; set; }

        public List<ProductCategory>? ProductCategories { get; set; }
    }
}
