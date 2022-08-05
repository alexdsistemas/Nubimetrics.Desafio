using System.Text.Json.Serialization;
#nullable disable

namespace DTOs.Busqueda
{
    public class ResultsDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("site_id")]
        public string SiteId { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }
        [JsonPropertyName("seller")]
        public SellerDto Seller { get; set; }
        [JsonPropertyName("permalink")]
        public string Permalink { get; set; }
    }
}
