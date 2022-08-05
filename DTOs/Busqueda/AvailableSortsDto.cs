using System.Text.Json.Serialization;

namespace DTOs.Busqueda
{
#nullable disable

    public class AvailableSortsDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
