using System.Text.Json.Serialization;

namespace Custodian.Properties.Estates.Domain.Entities
{
    public class Estate
    {
        [JsonPropertyName("estate_id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("estate_name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("estate_address")]
        public string Address { get; set; } = string.Empty;
    }
}
