using System.Text.Json.Serialization;

namespace Custodian.Properties.Estates.Domain.Entities
{
    public class Resident
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("first_name")]
        public string First_Name { get; set; } = string.Empty;

        [JsonPropertyName("last_name")]
        public string Last_Name { get; set; } = string.Empty;

        [JsonPropertyName("activation_pin")]
        public string Activation_Pin { get; set; } = string.Empty;

        [JsonPropertyName("activation_stage")]
        public string Activation_Stage { get; set; } = string.Empty;

        [JsonPropertyName("contacts")]
        public List<ResidentContact> Contacts { get; set; } = new List<ResidentContact>();
    }
}
