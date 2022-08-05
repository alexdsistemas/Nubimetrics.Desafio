using System.Text.Json.Serialization;
#nullable disable

namespace DTOs.Busqueda
{
    public class SortDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
