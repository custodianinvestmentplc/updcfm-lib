using System.Text.Json.Serialization;

namespace Custodian.Properties.Estates.Domain.Entities
{
    public class ResidentContact
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;

        [JsonPropertyName("default")]
        public bool IsDefault { get; set; }
    }
}
