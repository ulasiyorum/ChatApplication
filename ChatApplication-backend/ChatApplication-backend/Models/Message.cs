namespace ChatApplication_backend.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime SendDate { get; set; } = DateTime.Now;
        public MessageType Type { get; set; } = MessageType.Normal;
    }
}
