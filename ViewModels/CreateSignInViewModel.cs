using MessengerMvcApp.Models;

namespace MessengerMvcApp.ViewModels
{
    public class CreateSignInViewModel
    {
        public CreateAccount createAccount = new();
        public UserCredentials userCredentials = new();
    }
}
