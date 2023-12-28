using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels.Products
{
    public class ProductEditVM
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
    }
}
