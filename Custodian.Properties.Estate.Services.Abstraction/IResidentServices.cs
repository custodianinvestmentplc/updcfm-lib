using Custodian.Properties.Estates.Domain.Entities;

namespace Custodian.Properties.Estate.Services.Abstraction
{
    public interface IResidentServices
    {
        Resident GetResident(string? email, string? id);
        void ProcessLoginRequest(string residentId);
        void ProcessProfileActivationRequest(string residentId);
    }
}
