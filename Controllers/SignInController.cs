using MessengerMvcApp.Models;
using MessengerMvcApp.Services;
using MessengerMvcApp.ViewModels;
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

        public IActionResult CreateAccountView(CreateSignInViewModel createSignInVM)
        {
            return View(createSignInVM);
        }

        [HttpPost]
        public IActionResult Submit(CreateSignInViewModel createSignInVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createAccountmodel = new CreateAccount();
                    createAccountmodel = createSignInVM.createAccount;

                    bool isEmail = false;
                    bool isPassword = false;

                    GetDBData getDBData = new GetDBData();
                    DataTable dataTable = new DataTable();

                    string query = $"select * from UserDetails";

                    dataTable = getDBData.SelectData(query, _configuration);

                    var verifyEmailQuery = dataTable.AsEnumerable().Where(x => x.Field<string>("EmailID") == createAccountmodel.EmailID ? isEmail = true : isEmail = false);

                    var verifyPasswordQuery = dataTable.AsEnumerable().Where(x =>
                    x.Field<string>("Password") == createAccountmodel.Password ? isPassword = true : isPassword = false);

                    if (isEmail && isPassword)
                    {
                        return RedirectToAction("ChatsView", "Chats");
                    }

                    return View("CreateAccountView", createSignInVM);
                }
                else
                {
                    return View("CreateAccountView", createSignInVM);
                }
            }
            catch (Exception ex)
            {
                createSignInVM.createAccount.SqlErrorMessages = ex.Message + ex.Source + "stack trace: " + ex.StackTrace;
                return View("SignInView", createSignInVM);
            }
        }
    }
}