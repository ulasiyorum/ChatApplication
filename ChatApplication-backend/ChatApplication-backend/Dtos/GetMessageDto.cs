namespace ChatApplication_backend.Dtos
{
    public class GetMessageDto
    {
        public string Message { get; set; } = string.Empty;
        public DateTime SendDate { get; set; } = DateTime.Now;
        public string ColorHex { get; set; } = "#808080";
        public string Type { get; set; } = "Normal";
    }
}
