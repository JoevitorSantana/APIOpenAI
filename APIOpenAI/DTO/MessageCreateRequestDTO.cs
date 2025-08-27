namespace APIOpenAI.DTO
{
    public class MessageCreateRequestDTO
    {
        public string? Role { get; set; }
        public string? Content { get; set; }
        public Object[]? Attachments { get; set; }
        public Object? Metadata { get; set; }
    }
}
