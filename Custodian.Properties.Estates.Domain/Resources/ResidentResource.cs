using Custodian.Properties.Estates.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Custodian.Properties.Estates.Domain.Resources
{
    public class ResidentResource
    {
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
