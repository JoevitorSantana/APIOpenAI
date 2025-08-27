using APIOpenAI.DTO;

namespace APIOpenAI.Entities
{
    public class Message
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public string Run_id { get; set; }
        public string AssistantId { get; set; }
        public string ThreadId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Role { get; set; }
        public List<Object> Content { get; set; }
        public Object[] Attachments { get; set; }
        public Object Metadata {  get; set; }
        public Message() {
            InitializeObject();
        }

        private void InitializeObject()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
            this.Object = "thread.message";
            this.Content = new List<Object>();
            this.Metadata = new Object();
            this.Attachments = [];
        }

        public MessageResponseDTO toResponseDTO()
        {
            return new MessageResponseDTO() {
                Id = this.Id,
                Thread_Id = this.ThreadId,
                Object = this.Object,
                Assistant_Id = this.AssistantId,
                Attachments = this.Attachments,
                Content = this.Content,
                Metadata = this.Metadata,    
                Created_At = this.CreatedAt,
                Role = this.Role,
                Run_id = this.Run_id
            };
        }
    }
}
