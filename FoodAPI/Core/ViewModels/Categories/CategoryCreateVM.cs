using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.ViewModels.Category
{
    public class CategoryCreateVM
    {

        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
