using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels.Categories
{
    public class CategoryVM
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? TimeDeleted { get; set; }
    }
}
