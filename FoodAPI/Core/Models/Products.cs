using Core.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Products : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public List<ProductCategory>? ProductCategories { get; set; }
    }
}
