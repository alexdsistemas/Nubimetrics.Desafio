#nullable disable
using System.Text.Json.Serialization;

namespace DTOs.Paises
{
    public class GeoInformationDto
    {
        [JsonPropertyName("location")]
        public LocationDto Location { get; set; }
    }
}
