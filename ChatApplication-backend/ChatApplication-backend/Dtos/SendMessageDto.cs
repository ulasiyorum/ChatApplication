namespace ChatApplication_backend.Dtos
{
    public class SendMessageDto
    {
        public int SenderId { get; set; }
        public string Content { get; set; } = string.Empty;
        public MessageType Type { get; set; } = MessageType.Normal;
    }
}
