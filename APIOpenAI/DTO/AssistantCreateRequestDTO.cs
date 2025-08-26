namespace APIOpenAI.DTO
{
    public class AssistantCreateRequestDTO
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Instructions { get; set; }
        public Object[] Tools { get; set; }
    }
}
