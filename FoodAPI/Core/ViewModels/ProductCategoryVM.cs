using Core.ViewModels.Products;

namespace Core.ViewModels
{
    public class ProductCategoryVM
    {
        public ProductCreateVM? Product { get; set; }
        public List<string>? CategoryIDs { get; set; }
    }
}
