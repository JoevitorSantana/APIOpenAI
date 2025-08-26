namespace APIOpenAI.DTO
{
    public class ThreadCreateRequestDTO
    {
        public Object[]? Messages { get; set; }
        public Object? Tool_Resources { get; set; }
        public Object? Metadata { get; set; }

    }
}
