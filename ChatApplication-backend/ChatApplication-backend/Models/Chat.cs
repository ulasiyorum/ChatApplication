﻿namespace ChatApplication_backend.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
