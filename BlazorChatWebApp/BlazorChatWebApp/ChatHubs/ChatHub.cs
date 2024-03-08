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

            //var users = await chatRepo.GetAvailableUserAsync();
            //var users = GetUsers();
            //notify all clients 
            await Clients.All.SendAsync("NotifyAllClients",await GetUsers());
        }


        public async Task RemoveUserAsync(string userId)
        {
            await chatRepo.RemoveUserAsync(userId);
            await Clients.All.SendAsync("NotifyAllClients", await GetUsers());

        }

        private async Task<List<AvailableUserDTO>> GetUsers()
        {
            var users = await chatRepo.GetAvailableUserAsync();
            return users;
        }


    }
}
