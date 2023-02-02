using Custodian.Properties.Estate.Services.Abstraction;
using Custodian.Properties.Estates.Domain.Entities;
using Custodian.Properties.Estates.Helpers.Domains;
using Custodian.Properties.Estates.Helpers.Services;
using System.Data;

namespace Custodian.Properties.Estates.Services.Implementation
{
    public class ResidentServices : IResidentServices
    {
        private readonly IDbConnection _db;

        public ResidentServices(string dbconnectionString)
        {
            _db = Database.Connect(dbconnectionString);
        }

        public Resident GetResident(string? email, string? id)
        {
            Resident? resident = null;

            if (id == null && email != null)
            {
                resident = ResidentHelper.GetResidentByEmail(_db, email);
                List<ResidentContact> contacts = ResidentHelper.GetResidentContactList(_db, resident.Id);
                resident.Contacts = contacts;

                Unit unit = ResidentHelper.GetResidentUnit(_db, resident.Id);
                unit.EstateInfomation = ResidentHelper.GetResidentEstate(_db, resident.Id);


                return resident;
            }

            throw new ArgumentException("Bad Request. Cannot process command");
        }

        public void ProcessLoginRequest(string residentId)
        {
            throw new NotImplementedException();
        }

        public void ProcessProfileActivationRequest(string residentId)
        {
            throw new NotImplementedException();
        }
    }
}
