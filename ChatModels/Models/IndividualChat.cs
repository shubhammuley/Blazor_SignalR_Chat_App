﻿
namespace ChatModels.Models
{
    public class IndividualChat
    {

        public int Id { get; set; }
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }

        public string? message { get; set; }

        public DateTime Date { get; set; }
    }
}
