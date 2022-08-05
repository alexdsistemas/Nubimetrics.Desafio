using System.Text.Json.Serialization;
#nullable disable

namespace DTOs.Busqueda
{
    public class ValuesDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("path_from_root")]
        public List<PathFromRootDto> PathFromRoot { get; set; }
    }
}
