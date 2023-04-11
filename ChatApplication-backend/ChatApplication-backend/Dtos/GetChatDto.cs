namespace ChatApplication_backend.Dtos
{
    public class GetChatDto
    {
        public List<GetMessageDto>? Messages { get; set; }
        public string SenderUsername { get; set; } = string.Empty;
        public string ReceiverUsername { get; set; } = string.Empty;
    }
}
