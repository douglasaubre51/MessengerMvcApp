using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MessengerMvcApp.ViewModels;
using MessengerMvcApp.Models;
using MessengerMvcApp.Services;

namespace MessengerMvcApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult LoginView(LoginViewModel loginViewModel)
        {
            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Submit(LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool emailExists = true;
                    bool passwordExists = true;

                    GetDBData getDBData = new GetDBData();
                    DataTable dataTable = new DataTable();

                    string query = $"select * from UserDetails";

                    dataTable = getDBData.SelectData(query, _configuration);

                    var verifyEmailQuery = dataTable.AsEnumerable().FirstOrDefault(x => x.Field<string>("EmailID") == loginViewModel.loginModel.EmailID);

                    emailExists = verifyEmailQuery != null ? true : false;

                    var verifyPasswordQuery = dataTable.AsEnumerable().FirstOrDefault(x =>
                    x.Field<string>("Password") == loginViewModel.loginModel.Password);

                    passwordExists = verifyPasswordQuery != null ? true : false;

                    if (emailExists && passwordExists)
                    {
                        return RedirectToAction("ChatsView", "Chats");
                    }

                    return View("LoginView", loginViewModel);
                }
                else
                {
                    return View("LoginView", loginViewModel);
                }
            }
            catch (Exception ex)
            {
                loginViewModel.SqlErrorMessages = ex.Message + ex.Source + "stack trace: " + ex.StackTrace;
                return View("SqlError", loginViewModel);
            }
        }

        public IActionResult SqlError(LoginViewModel loginViewModel)
        {
            return View(loginViewModel);
        }
    }
}