using ChatModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorChatWebApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) 
    {
        public DbSet<Chat> Chats { get; set; }
    }
}

    

     


    
