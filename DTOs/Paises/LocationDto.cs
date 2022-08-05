#nullable disable

using System.Text.Json.Serialization;

namespace DTOs.Paises
{
    public class LocationDto
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}
