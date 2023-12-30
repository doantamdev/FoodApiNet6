using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels.Users
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }


        //[DataType(DataType.Date)]
        //public DateTime Dob { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }
    }
}
