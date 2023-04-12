namespace ChatApplication_backend.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
        public List<int> ReceiverDeletedMessages { get; set; } = new List<int>();
        public List<int> SenderDeletedMessages { get; set; } = new List<int>();
    }
}
