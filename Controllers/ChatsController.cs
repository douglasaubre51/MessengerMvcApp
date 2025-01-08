using MessengerMvcApp.Models;
using MessengerMvcApp.Services;
using MessengerMvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MessengerMvcApp.Controllers
{
    public class ChatsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ChatsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult ChatsView()
        {
            ChatsViewModel chatsViewModel = new ChatsViewModel();
            var model = new List<Chats>();
            GetDBData getDBData = new GetDBData();
            DataTable dataTable;

            string query = "select * from UserDetails";

            try
            {
                dataTable = getDBData.SelectData(query, _configuration);

                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        model.Add(
                            new Chats
                            {
                                Name = (string)row["UserName"],
                                Email = (string)row["EmailID"],
                                Date = (DateTime)row["Date"],
                                Message = (string)row["Conversation"]
                            });

                    }
                }

                chatsViewModel.chats = model;
            }
            catch (Exception ex)
            {
                chatsViewModel.SqlErrorMessages = ex.Message + ex.StackTrace;
                return View("SqlError", chatsViewModel);
            }

            return View(chatsViewModel);
        }

        public IActionResult SqlError(ChatsViewModel chatsViewModel)
        {
            return View(chatsViewModel);
        }
    }
}