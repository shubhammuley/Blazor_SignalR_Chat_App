using BlazorChatWebApp.Authentication;
using BlazorChatWebApp.Client.DTOs;
using BlazorChatWebApp.Data;
using BlazorChatWebApp.Models;
using ChatModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorChatWebApp.Migrations.Repos
{
    public class ChatRepo(AppDbContext appDbContext, UserManager<AppUser> userManager )
    {
        public async Task SaveChatAsync(Chat chat)
        {
            appDbContext.Chats.Add( chat );
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<Chat>> GetChatAsync() =>
            await appDbContext.Chats.ToListAsync();


        public async Task AddAvailableUserAsync(AvailableUser availableUser)
        {
            var getUser = await appDbContext.
                AvailableUsers.FirstOrDefaultAsync(
                _ => _.UserId == availableUser.UserId
                );

            if(getUser is null)
            {
                getUser.ConnectionId = availableUser.ConnectionId;
            }
            else
            {
                appDbContext.AvailableUsers.Add( availableUser );
            }

            await appDbContext.SaveChangesAsync();
        }


        public async Task<List<AvailableUserDTO>> GetAvailableUserAsync()
        {
            var list = new List<AvailableUserDTO>();

            var users = await appDbContext.AvailableUsers.ToListAsync();

            foreach( var u in users ) {
                list.Add(new AvailableUserDTO(
                    UserId: u.UserId,
                    ConnectionId: u.ConnectionId,
                    Fullname : (await userManager.FindByIdAsync(u.UserId)!)!.Fullname,
                    Email : (await userManager.FindByIdAsync(u.UserId!)!)!.Email!
                    ));
            }
            return list;
        }
    }
}
