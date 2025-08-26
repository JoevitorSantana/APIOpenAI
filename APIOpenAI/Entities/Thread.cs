using System.Globalization;
using APIOpenAI.DTO;

namespace APIOpenAI.Entities
{
    public class Thread
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Object Metadata { get; set; }
        public Object ToolResources { get; set; }

        public Thread()
        {
            InitializeObject();
        }

        private void InitializeObject()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }

        public ThreadResponseDTO toResponseDTO()
        {
            return new ThreadResponseDTO
            {
                Id = this.Id,
                Metadata = this.Metadata,
                Tool_Resources = this.ToolResources,
                Created_At = CreatedAt,
            };
        }
    }
}
