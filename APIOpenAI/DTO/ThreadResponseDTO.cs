namespace APIOpenAI.DTO
{
    public class ThreadResponseDTO
    {
        public string Id { get; set; }
        public DateTime Created_At { get; set; }
        public Object Metadata { get; set; }
        public Object Tool_Resources { get; set; }
    }
}
