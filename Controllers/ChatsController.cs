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

        public IActionResult ChatsView(ChatsViewModel chatsViewModel)
        {
            GetDBData getDBData = new GetDBData();

            var model = new List<Chats>();

            DataTable dataTable = new DataTable();

            string query = "select UserName,EmailID,Conversation,Date from UserDetails";

            try
            {
                dataTable = getDBData.SelectData(query, _configuration);

                foreach (DataRow row in dataTable.Rows)
                {
                    model.Add(
                        new Chats
                        {
                            Name = (string)row["UserName"],
                            Email = (string)row["EmailID"],
                            Date = (DateTime?)row["Date"],
                            Message = (string)row["Conversation"]
                        });
                }
            }
            catch (Exception ex)
            {
                chatsViewModel.SqlErrorMessages = ex.Message;
                return View("SqlError", chatsViewModel);
            }

            chatsViewModel.chats = model;
            return View(chatsViewModel);
        }

        public IActionResult SqlError(ChatsViewModel chatsViewModel)
        {
            return View(chatsViewModel);
        }
    }
}