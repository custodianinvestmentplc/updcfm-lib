using Custodian.Properties.Estates.Domain.Entities;

namespace Custodian.Properties.Estates.Domain.Resources
{
    public class EstateResource
    {
        public Estate Estate { get; set; } = new Estate();

        public List<Unit> Unit { get; set; } = new List<Unit>();
    }
}
