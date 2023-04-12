namespace ChatApplication_backend.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public List<int>? Chats { get; set; }
    }
}
