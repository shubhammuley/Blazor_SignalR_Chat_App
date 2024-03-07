using BlazorChatWebApp.Data;
using ChatModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorChatWebApp.Migrations.Repos
{
    public class ChatRepo(AppDbContext appDbContext )
    {
        public async Task SaveChatAsync(Chat chat)
        {
            appDbContext.Chats.Add( chat );
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<Chat>> GetChatAsync() =>
            await appDbContext.Chats.ToListAsync();
    }
}
