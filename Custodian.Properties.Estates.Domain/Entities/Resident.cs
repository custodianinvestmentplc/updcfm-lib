using System.Text.Json.Serialization;

namespace Custodian.Properties.Estates.Domain.Entities
{
    public class Resident
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("last_name")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("activation_pin")]
        public string ActivationPin { get; set; } = string.Empty;

        [JsonPropertyName("activation_stage")]
        public string ActivationStage { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string PasswordHash { get; set; } = string.Empty;

        [JsonPropertyName("contacts")]
        public List<ResidentContact> Contacts { get; set; } = new List<ResidentContact>();
    }
}
