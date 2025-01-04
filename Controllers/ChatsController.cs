using MessengerMvcApp.Models;
using MessengerMvcApp.Services;
using MessengerMvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace MessengerMvcApp.Controllers
{
    public class ChatsController : Controller, IGetDBData
    {
        private readonly IConfiguration _configuration;
        private readonly IGetDBData _getDBData;

        public ChatsController(IConfiguration configuration, IGetDBData getDBData)
        {
            _configuration = configuration;
            _getDBData = getDBData;
        }

        public IActionResult ChatsView(ChatsViewModel chatsViewModel)
        {
            var model = new List<ChatsModel>();
            DataTable dataTable = new DataTable();
            string query = "select UserName,EmailID,Conversation,Date from UserDetails";

            try
            {
                dataTable = _getDBData.SelectData(query, _configuration);

                foreach (DataRow row in dataTable.Rows)
                {
                    model.Add(
                        new ChatsModel
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
                return View("SqlError", ex.Message);
            }

            chatsViewModel.chatsModels = model;
            return View(chatsViewModel);
        }

        public IActionResult SqlError(string message)
        {
            return View(message);
        }
    }
}
