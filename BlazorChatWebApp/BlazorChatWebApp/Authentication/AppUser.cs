using Microsoft.AspNetCore.Identity;

namespace BlazorChatWebApp.Authentication
{
    public class AppUser : IdentityUser 
    {
        public string FullName { get; set; } = string.Empty;

    }
}
