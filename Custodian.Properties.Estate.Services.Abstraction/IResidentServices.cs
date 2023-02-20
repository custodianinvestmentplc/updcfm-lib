using Custodian.Properties.Estates.Domain.Dto;
using Custodian.Properties.Estates.Domain.Entities;
using Custodian.Properties.Estates.Domain.Resources;

namespace Custodian.Properties.Estate.Services.Abstraction
{
    public interface IResidentServices
    {
        ResidentResource GetResident(string? email, string? id);
        Resident ResidentCreatePassword(ResidentDto resident, string password);
        ResidentResource ResidentLogin(string email, string password);
        void ProcessLoginRequest(string residentId);
        void ProcessProfileActivationRequest(string residentId);
    }
}
