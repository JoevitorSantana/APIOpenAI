using APIOpenAI.DTO;

namespace APIOpenAI.Entities
{
    public class Assistant
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Instructions { get; set; }
        public Object[] Tools { get; set; }
        public Object Metadata { get; set; }
        public double Topp { get; set; }
        public double Temperature { get;set; }
        public string ResponseFormat { get; set; }

        public Assistant()
        {
            InitializeObject();
        }

        private void InitializeObject()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
            this.Object = "assistant";
            this.Metadata  = new Object();
            this.Topp  = 1.0f;
            this.Temperature  = 1.0f;
            this.ResponseFormat  = "auto";
        }

        public AssistantResponseDTO toResponseDTO()
        {
            AssistantResponseDTO response = new AssistantResponseDTO()
            {
                Id = this.Id,
                Object = this.Object,
                Created_At = this.CreatedAt,
                Name = this.Name,
                Description = this.Description,
                Model = this.Model,
                Instructions = this.Instructions,
                Tools = this.Tools,
                Metadata = this.Metadata,
                Top_p = this.Topp,
                Temperature = this.Temperature,
                Response_Format = this.ResponseFormat,
            };

            return response;
        }
    }
}
