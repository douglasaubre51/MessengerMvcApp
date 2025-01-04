using MessengerMvcApp.Models;
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
        public IActionResult Submit(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ChatsView", "Chats");
            }
            else
            {
                return View("SignInView", model);
            }
        }
    }
}
