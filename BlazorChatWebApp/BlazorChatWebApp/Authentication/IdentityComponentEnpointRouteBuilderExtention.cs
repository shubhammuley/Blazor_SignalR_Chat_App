using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BlazorChatWebApp.Authentication
{
    internal static  class IdentityComponentEnpointRouteBuilderExtention
    {

        public static IEndpointConventionBuilder MapAdditionalIdentityEndpoint(this IEndpointRouteBuilder endpoint)
        {
            var accountGroup = endpoint.MapGroup("/Account");
            accountGroup.MapPost("/Logout", async(ClaimsPrincipal user, SignInManager<AppUser> signInManager)
                =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.LocalRedirect("/Account/Login");
            });
            return accountGroup;
        }
    }
}
