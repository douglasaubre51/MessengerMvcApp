using MessengerMvcApp.Models;

namespace MessengerMvcApp.ViewModels
{
    public class LoginViewModel
    {
        public LoginModel loginModel;
        public string? SqlErrorMessages { get; set; }

        public bool emailExists { get; set; }
        public bool passwordExists { get; set; }
    }
}