using System.Text.Json.Serialization;

namespace DTOs.Busqueda
{
    public class PagingDto
    {
        [JsonPropertyName("total")]
        public long Total { get; set; }
        [JsonPropertyName("primary_results")]
        public long PrimaryResults { get; set; }
        [JsonPropertyName("offset")]
        public long Offset { get; set; }
        [JsonPropertyName("limit")]
        public long Limit { get; set; }
    }
}
