using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApplication_backend.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();


        [NotMapped]
        public List<int> ReceiverDeletedMessages { get; set; } = new List<int>();
        [NotMapped]
        public List<int> SenderDeletedMessages { get; set; } = new List<int>();
    }
}
