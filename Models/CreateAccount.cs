using System.ComponentModel.DataAnnotations;

namespace MessengerMvcApp.Models
{
    public class CreateAccount
    {
        [Required(ErrorMessage = "name is required!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "email is required!")]
        [DataType(DataType.EmailAddress)]
        public string? EmailID { get; set; }

        [Required(ErrorMessage = "password is required!")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "password should atleast contain 8 characters!")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "passwords do not match!")]
        public string? ConfirmPassword { get; set; }
        public string? SqlErrorMessages { get; set; }
    }
}