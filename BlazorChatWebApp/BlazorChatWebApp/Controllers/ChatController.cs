using BlazorChatWebApp.Migrations.Repos;
using ChatModels;
using ChatModels.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorChatWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController(ChatRepo chatRepo) : ControllerBase
    {
        [HttpGet("group-chats")]
        public async Task<IActionResult> GetGroupChatsAsync() =>
            Ok(await chatRepo.GetGroupChatsAsync());

       
        [HttpGet("users")]
        public async Task<IActionResult> GetUsersAsync() =>
            Ok(await chatRepo.GetAvailableUsersAsync());

        [HttpGet("individual")]
        public async Task<IActionResult> GetIndividualChatsAsync(RequestChatDTO requestChatDTO) =>
            Ok(await chatRepo.GetIndividualChatsAsync(requestChatDTO));

    }
}
