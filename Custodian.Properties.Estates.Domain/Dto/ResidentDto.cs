namespace Custodian.Properties.Estates.Domain.Dto
{
    public class ResidentDto
    {
        public string? Id { get; set; }
        public string? email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ContactDto? Contact { get; set; } = new ContactDto();
    }
}
