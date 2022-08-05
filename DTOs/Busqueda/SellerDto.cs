using System.Text.Json.Serialization;

namespace DTOs.Busqueda
{
    public class SellerDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
    }
}
