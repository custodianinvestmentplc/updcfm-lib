using Custodian.Properties.Estates.Domain.Entities;
using Custodian.Properties.Estates.Domain.Resources;

namespace Custodian.Properties.Estate.Services.Abstraction
{
    public interface IResidentServices
    {
        ResidentResource GetResident(string? email, string? id);
        void ProcessLoginRequest(string residentId);
        void ProcessProfileActivationRequest(string residentId);
    }
}
