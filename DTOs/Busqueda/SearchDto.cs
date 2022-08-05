using System.Text.Json.Serialization;
#nullable disable

namespace DTOs.Busqueda
{
    public class SearchDto
    {
        [JsonPropertyName("site_id")]
        public string SiteId { get; set; }
        [JsonPropertyName("country_default_time_zone")]
        public string CountryDefaultTimeZone { get; set; }
        [JsonPropertyName("query")]
        public string Query { get; set; }
        [JsonPropertyName("paging")]
        public PagingDto Paging { get; set; }
        [JsonPropertyName("results")]
        public List<ResultsDto> Results { get; set; }
        [JsonPropertyName("sort")]
        public SortDto Sort { get; set; }
        [JsonPropertyName("available_sorts")]
        public List<AvailableSortsDto> AvailableSorts { get; set; }
        [JsonPropertyName("filters")]
        public List<FiltersDto> Filters { get; set; }
        [JsonPropertyName("available_filters")]
        public List<AvailableFiltersDto> AvailableFilters { get; set; }
    }
}
