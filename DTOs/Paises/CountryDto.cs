#nullable disable
using System.Text.Json.Serialization;

namespace DTOs.Paises
{
    public class CountryDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("locale")]
        public string Locale { get; set; }
        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }
        [JsonPropertyName("decimal_separator")]
        public string DecimalSeparator { get; set; }
        [JsonPropertyName("thousands_separator")]
        public string ThousandsSeparator { get; set; }
        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }
        [JsonPropertyName("geo_information")]
        public GeoInformationDto GeoInformation { get; set; }
        [JsonPropertyName("states")]
        public List<StatesDto> States { get; set; }
    }
}
