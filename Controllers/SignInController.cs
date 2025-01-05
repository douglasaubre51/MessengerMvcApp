using MessengerMvcApp.Models;
using MessengerMvcApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MessengerMvcApp.Controllers
{
    public class SignInController : Controller
    {
        private readonly IConfiguration _configuration;

        public SignInController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult SignInView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                GetDBData getDBData = new GetDBData();
                DataTable dataTable = new DataTable();

                string query = "select EmailID,Password from UserDetails where EmailID=@emailId";
                
                dataTable = getDBData.SelectData(query, _configuration);

                if (dataTable.Rows.Count == 0)
                {
                    return View("SignInView", model);
                }



                return RedirectToAction("ChatsView", "Chats");
            }
            else
            {
                return View("SignInView", model);
            }
        }
    }
}
