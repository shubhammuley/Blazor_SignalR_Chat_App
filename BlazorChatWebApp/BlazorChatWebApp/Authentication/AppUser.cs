using Microsoft.AspNetCore.Identity;

namespace BlazorChatWebApp.Authentication
{
    public class AppUser : IdentityUser 
    {
        public string Fullname { get; set; } = string.Empty;

    }
}
