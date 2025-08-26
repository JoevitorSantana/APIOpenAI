namespace APIOpenAI.DTO
{
    public class ThreadModifyRequestDTO
    {
        public Object[]? Messages { get; set; }
        public Object? Tool_Resources { get; set; }
        public Object? Metadata { get; set; }
    }
}
