using BlazorChatWebApp.Authentication;
using BlazorChatWebApp.Client.DTOs;
using ChatModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorChatWebApp.Data
{
    public class AppDbContext :IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<AvailableUser> AvailableUsers { get; set; }
    }
}

    

     


    
