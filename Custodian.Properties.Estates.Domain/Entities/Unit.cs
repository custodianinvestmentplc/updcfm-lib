using System.Text.Json.Serialization;

namespace Custodian.Properties.Estates.Domain.Entities
{
    public class Unit
    {
        [JsonPropertyName("unit_id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("unit_number")]
        public string Unit_Number { get; set; } = string.Empty;

        [JsonPropertyName("estate")]
        public Estate EstateInfomation { get; set; } = new Estate();
    }
}
