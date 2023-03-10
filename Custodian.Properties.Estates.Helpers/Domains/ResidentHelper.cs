using Custodian.Properties.Estates.Domain.Entities;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System.Data;

namespace Custodian.Properties.Estates.Helpers.Domains
{
    public static class ResidentHelper
    {
        public static Resident GetResidentByEmail(IDbConnection db, string email)
        {
            string sp = "dbo.find_resident";
            DynamicParameters parm = new DynamicParameters();

            parm.Add("@email_address", email);

            var lst = DbStore.LoadData<Resident>(db, sp, parm);

            if (lst != null && lst.Count == 1)
            {
                return lst[0];
            }

            throw new KeyNotFoundException($"Resident with email address {email} was not found.");
        }

        public static List<ResidentContact> GetResidentContactList(IDbConnection db, string residentId)
        {
            string sp = "dbo.get_resident_contact";
            DynamicParameters parm = new DynamicParameters();

            parm.Add("@resident_id", residentId);

            var lst = DbStore.LoadData<ResidentContact>(db, sp, parm);

            return lst;
        }

        public static Resident GetResidentById(IDbConnection db, string id)
        {
            string sp = "dbo.find_resident";
            DynamicParameters parm = new DynamicParameters();

            parm.Add("@email_address", id);

            var lst = DbStore.LoadData<Resident>(db, sp, parm);

            if (lst != null && lst.Count == 1)
            {
                return lst[0];
            }

            throw new KeyNotFoundException($"Resident with Id of {id} was not found.");
        }

        public static void Login(IDbConnection db, string residentId)
        {
            throw new NotImplementedException();
        }

        public static void ActivateLoginProfile(IDbConnection db, string residentId)
        {
            throw new NotImplementedException();
        }
    }
}
