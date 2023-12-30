using Core.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Core.Models
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? TimeDeleted { get; set; }
    }
}
