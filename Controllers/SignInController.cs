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
            try
            {
                model = new SignInModel();

                if (ModelState.IsValid)
                {
                    bool isEmail = false;
                    bool isPassword = false;

                    GetDBData getDBData = new GetDBData();
                    DataTable dataTable = new DataTable();

                    string query = $"select * from UserDetails";

                    dataTable = getDBData.SelectData(query, _configuration);

                    var verifyEmailQuery = from row in dataTable.AsEnumerable()
                                           where row.Field<string>("EmailID") == model.EmailID
                                           select row;

                    foreach (var row in verifyEmailQuery)
                    {
                        if (row == null)
                        {
                            break;
                        }
                        else
                        {
                            isEmail = true;
                            break;
                        }
                    }

                    var verifyPasswordQuery = from row in dataTable.AsEnumerable()
                                              where row.Field<string>("Password") == model.Password
                                              select row;

                    foreach (var row in verifyPasswordQuery)
                    {
                        if (row == null)
                        {
                            break;
                        }
                        else
                        {
                            isPassword = true;
                            break;
                        }
                    }

                    model.isEmail = isEmail;
                    model.isPassword = isPassword;

                    if (isEmail && isPassword)
                    {
                        return RedirectToAction("ChatsView", "Chats");
                    }

                    return View("SignInView", model);
                }
                else
                {
                    return View("SignInView", model);
                }
            }
            catch (Exception ex)
            {
                model.SqlErrorMessages = ex.Message + ex.Source + "stack trace: " + ex.StackTrace;
                return View("SignInView", model);
            }
        }
    }
}
