using System.Text.Json.Serialization;

namespace Custodian.Properties.Estates.Domain.Entities
{
    public class ResidentContact
    {
        [JsonPropertyName("type")]
        public string Contact_Type { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public string Contact_Value { get; set; } = string.Empty;

        [JsonPropertyName("default")]
        public string Is_Default { get; set; } = string.Empty;
    }
}
