using Microsoft.AspNetCore.Mvc;

namespace MessengerMvcApp.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult SignInView()
        {
            return View();
        }
    }
}
