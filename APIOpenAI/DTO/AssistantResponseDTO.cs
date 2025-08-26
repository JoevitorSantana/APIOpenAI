namespace APIOpenAI.DTO
{
    public class AssistantResponseDTO
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public DateTime Created_At { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Instructions { get; set; }
        public Object[] Tools { get; set; }
        public Object Metadata { get; set; }
        public double Top_p { get; set; }
        public double Temperature { get; set; }
        public string Response_Format { get; set; }
    }
}
