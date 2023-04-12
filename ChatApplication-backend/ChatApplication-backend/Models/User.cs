using System.ComponentModel.DataAnnotations;

namespace ChatApplication_backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public List<Chat>? Chats { get; set; }
    }
}
