using BlazorChatWebApp.Migrations.Repos;
using ChatModels;
using ChatModels.DTOs;
using ChatModels.Models;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChatWebApp.ChatHubs
{
    public class ChatHub(ChatRepo chatRepo) : Hub
    {

        public async Task SendMessageToGroup(GroupChatModel chat)
        {
            var saveChatDTO = await chatRepo.AddChatToGroupAsync(chat);
            await Clients.All.SendAsync("ReceiveGroupMessages", saveChatDTO);
        }

        public async Task AddAvailableUser(AvailableUser availableUser)
        {
            availableUser.ConnectionId = Context.ConnectionId;
            var availableUsers =  await chatRepo.AddAvailableUser(availableUser);
            await Clients.All.SendAsync("NotifyAllClients", availableUsers);
        }


        public async Task RemoveUserAsync(string userId)
        {
           var availabelUsers =  await chatRepo.RemoveUserAsync(userId);
            await Clients.All.SendAsync("NotifyAllClients", availabelUsers);

        }

        public async Task AddIndividualChat(IndividualChat individualChat)
        {
            await chatRepo.AddIndividualChatAsync(individualChat);
            var requestId = new RequestChatDTO()
            {
                ReceiverId = individualChat.ReceiverId,
                SenderId = individualChat.SenderId,
            };

            var getChats = await chatRepo.GetIndividualChatsAsync(requestId);

            var prepareIndividualChat = new IndividualChatDTO()
            {
                SenderId = individualChat.SenderId,
                ReceiverId = individualChat.ReceiverId,
                message = individualChat.message,
                Date = individualChat.Date,
                ReceiverName = getChats.Where(_ => _.ReceiverId == individualChat.ReceiverId).FirstOrDefault()!.ReceiverName,
                SenderName = getChats.Where(_ => _.SenderId == individualChat.SenderId).FirstOrDefault()!.SenderName
            };
            await Clients.User(individualChat.ReceiverId!).SendAsync("ReceiveIndividualMessage", prepareIndividualChat);
        }

    }
}
