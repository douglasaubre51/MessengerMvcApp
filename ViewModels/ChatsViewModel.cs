using MessengerMvcApp.Models;

namespace MessengerMvcApp.ViewModels
{
    public class ChatsViewModel
    {
        public List<Chats> chats = new List<Chats>();
        public string? SqlErrorMessages { get; set; }
    }
}