using MessengerMvcApp.Models;

namespace MessengerMvcApp.ViewModels
{
    public class LoginViewModel
    {
        public LoginModel loginModel = new();
        public string? SqlErrorMessages { get; set; }
    }
}