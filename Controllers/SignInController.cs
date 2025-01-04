using Microsoft.AspNetCore.Mvc;

namespace MessengerMvcApp.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult SignInView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit()
        {
            return RedirectToAction("ChatsView", "Chats");
        }
    }
}
