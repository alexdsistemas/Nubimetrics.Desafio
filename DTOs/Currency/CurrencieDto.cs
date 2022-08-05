using System.Text.Json.Serialization;
#nullable disable

namespace DTOs.Currency
{
    public class CurrencieDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("descripcion")]
        public string Description { get; set; }
        [JsonPropertyName("decimal_places")]
        public uint DecimalPlaces { get; set; }
        [JsonPropertyName("todolar")]
        public CurrencyConversionDto Todolar { get; set; }
    }
}
