using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels.Users
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
