﻿namespace BlazorChatWebApp.Client.DTOs
{
    public record AvailableUserDTO(
        string UserId, string ConnectionId, string Fullname,
        string Email);
}
