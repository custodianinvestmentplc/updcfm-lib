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

        public string First_Name { get; set; } = string.Empty;

        [JsonPropertyName("last_name")]
        public string Last_Name { get; set; } = string.Empty;

        [JsonPropertyName("activation_pin")]
        public string Activation_Pin { get; set; } = string.Empty;

        [JsonPropertyName("activation_stage")]
        public string Activation_Stage { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password_Hash { get; set; } = string.Empty;

        [JsonPropertyName("contacts")]
        public List<ResidentContact> Contacts { get; set; } = new List<ResidentContact>();

        [JsonPropertyName("unit")]
        public Unit unit { get; set; } = new Unit();

    }
}
