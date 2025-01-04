using MessengerMvcApp.Models;

namespace MessengerMvcApp.ViewModels
{
    public class ChatsViewModel
    {
        public List<ChatsModel> chatsModels = new List<ChatsModel>();
        public string? SqlErrorMessages { get; set; }
    }
}
