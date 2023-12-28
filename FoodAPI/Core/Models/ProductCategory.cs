using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class ProductCategory
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? TimeDeleted { get; set; }
        public Products? Products { get; set; }
        public Category? Category { get; set; }

    }
}
