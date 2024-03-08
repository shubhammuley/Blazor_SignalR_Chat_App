using BlazorChatWebApp.Authentication;

using ChatModels.DTOs;
using ChatModels.Models;
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
        public DbSet<GroupChatModel> GroupChats { get; set; }
        public DbSet<AvailableUser> AvailableUsers { get; set; }
        public DbSet<IndividualChat> IndividualChats { get; set; }
    }
}

    

     


    
