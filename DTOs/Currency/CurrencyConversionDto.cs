using System.Text.Json.Serialization;
#nullable disable

namespace DTOs.Currency
{
    public class CurrencyConversionDto
    {
        [JsonPropertyName("currency_base")]
        public string CurrencyBase { get; set; }
        [JsonPropertyName("currency_quote")]
        public string CurrencyQuote { get; set; }
        [JsonPropertyName("ratio")]
        public double Ratio { get; set; }
        [JsonPropertyName("rate")]
        public double Rate { get; set; }
        [JsonPropertyName("inv_rate")]
        public double InvRate { get; set; }
        [JsonPropertyName("creation_date")]
        public DateTime CreatinDate { get; set; }
        [JsonPropertyName("valid_until")]
        public DateTime ValidUntil { get; set; }

    }
}
