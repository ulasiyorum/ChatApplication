using System.Text.Json.Serialization;

namespace ChatApplication_backend.Dtos
{
    public class GetChatDto
    {
        public int Id { get; set; }
        public List<GetMessageDto>? Messages { get; set; }
        public List<int> DeletedMessages { get; set; } = new List<int>();
        public string SenderUsername { get; set; } = string.Empty;
        public string ReceiverUsername { get; set; } = string.Empty;
        public Status IsSenderOrReceiver { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Sender,
        Receiver
    }
}
