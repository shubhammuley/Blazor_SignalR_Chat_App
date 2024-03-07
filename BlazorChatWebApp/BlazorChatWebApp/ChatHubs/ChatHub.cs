using BlazorChatWebApp.Client.DTOs;
using BlazorChatWebApp.Migrations.Repos;
using ChatModels;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChatWebApp.ChatHubs
{
    public class ChatHub(ChatRepo chatRepo) : Hub
    {

        public async Task SendMessage(Chat chat)
        {
            await chatRepo.SaveChatAsync(chat);
            await Clients.All.SendAsync("ReceiveMessage",chat);
        }

        public async Task AddAvailableUserAsync(AvailableUser availableUser)
        {
            availableUser.ConnectionId = Context.ConnectionId;
            await chatRepo.AddAvailableUserAsync(availableUser);

            var users = chatRepo.GetAvailableUserAsync();
            //notify all clients 
            await Clients.All.SendAsync("NotifyAllClients", users);
        }





    }
}
