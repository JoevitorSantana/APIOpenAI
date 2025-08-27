namespace APIOpenAI.DTO
{
    public class MessageResponseDTO
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public string Assistant_Id { get; set; }
        public string Run_id { get; set; }
        public string Thread_Id { get; set; }
        public DateTime Created_At { get; set; }
        public string Role { get; set; }
        public List<Object> Content { get; set; }
        public Object[] Attachments { get; set; }
        public Object Metadata { get; set; }
    }
}
