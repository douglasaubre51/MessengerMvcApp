using MessengerMvcApp.Models;

namespace MessengerMvcApp.ViewModels
{
    public class ChatsViewModel
    {
        public List<Chats> chats;
        public string? SqlErrorMessages { get; set; }
    }
}