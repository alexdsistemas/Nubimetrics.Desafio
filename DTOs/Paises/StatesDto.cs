#nullable disable
using System.Text.Json.Serialization;

namespace DTOs.Paises
{
    public class StatesDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
