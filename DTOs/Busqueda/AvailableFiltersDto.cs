using System.Text.Json.Serialization;
#nullable disable

namespace DTOs.Busqueda
{
    public class AvailableFiltersDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("values")]
        public List<ValuesAvailableFiltersDto> Values { get; set; }
    }
}
