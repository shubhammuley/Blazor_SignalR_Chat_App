﻿using BlazorChatWebApp.Migrations.Repos;
using ChatModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorChatWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController(ChatRepo chatRepo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Chat>>> GetChatAsync() =>
            Ok(await chatRepo.GetChatAsync());



        [HttpGet("users")]
        public async Task<ActionResult<List<Chat>>> GetAvailableUsersAsync() =>
            Ok(await chatRepo.GetAvailableUserAsync());

    }
}
