using System.Text.Json.Serialization;

namespace Custodian.Properties.Estates.Domain.Entities
{
    public class Estate
    {
        [JsonPropertyName("estate_id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("estate_name")]
        public string Estate_Name { get; set; } = string.Empty;

        [JsonPropertyName("estate_address")]
        public string Estate_Address { get; set; } = string.Empty;
    }
}
