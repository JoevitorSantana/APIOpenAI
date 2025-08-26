using System.Text.Json.Serialization;

namespace APIOpenAI.DTO
{
    public class DeleteResponseDTO
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public bool Deleted { get; set; }
    }
}
