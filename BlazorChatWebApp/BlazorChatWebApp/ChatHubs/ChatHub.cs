using ChatModels;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChatWebApp.ChatHubs
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(Chat chat)
        {
            await Clients.All.SendAsync("ReceiveMessage",chat);
        }






    }
}
