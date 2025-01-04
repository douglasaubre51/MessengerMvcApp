using Microsoft.AspNetCore.Mvc;

namespace MessengerMvcApp.Controllers
{
    public class ChatsController : Controller
    {
        public IActionResult ChatsView()
        {
            return View();
        }
    }
}
