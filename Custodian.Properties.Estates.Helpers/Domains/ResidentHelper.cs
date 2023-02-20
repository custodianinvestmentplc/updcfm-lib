using Custodian.Properties.Estates.Domain.Dto;
using Custodian.Properties.Estates.Domain.Entities;
using Custodian.Properties.Estates.Domain.Resources;
using Custodian.Properties.Estates.Helpers.Services;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System.Data;

namespace Custodian.Properties.Estates.Helpers.Domains
{
    public static class ResidentHelper
    {
        public static ResidentResource GetResidentByEmail(IDbConnection db, string email)
        {
            string sp = "dbo.find_resident";
            DynamicParameters parm = new DynamicParameters();

            parm.Add("@email_address", email);

            var lst = DbStore.LoadData<ResidentResource>(db, sp, parm);

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

        public static Unit GetResidentUnit(IDbConnection db, string residentId)
        {
            string sp = "dbo.get_resident_unit";
            DynamicParameters parm = new DynamicParameters();

            parm.Add("@resident_id", residentId);

            var lst = DbStore.LoadData<Unit>(db, sp, parm);

            if(lst != null && lst.Count == 1)
            {
                return lst[0];
            }

            throw new KeyNotFoundException($"Unit with Id of {residentId} was not found.");

        }

        public static Estate GetResidentEstate(IDbConnection db, string residentId)
        {
            string sp = "dbo.get_resident_estate";
            DynamicParameters parm = new DynamicParameters();

            parm.Add("@resident_id", residentId);

            var lst = DbStore.LoadData<Estate>(db, sp, parm);

            if (lst != null && lst.Count == 1)
            {
                return lst[0];
            }

            throw new KeyNotFoundException($"Estate with Id of {residentId} was not found.");

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

        public static Resident ResidentCreatePassword(IDbConnection db, ResidentDto resident, string password)
        {
            string sp = "dbo.resident_create_password";
            DynamicParameters prm = new DynamicParameters();

            var password_hash = Encryption.EnhanceHashPasswordWithBcrypt(password);
            
           
            prm.Add("@resident_id", resident.Id);
            prm.Add("@password", password_hash);

            DbStore.SaveData(db, sp, prm);

            string storedP = "dbo.find_resident";
            DynamicParameters par = new DynamicParameters();

            par.Add("@resident_id", resident.Id);

            var updatedResident = DbStore.LoadData<Resident>(db, storedP, par);

            if (updatedResident != null && updatedResident.Count == 1)
            {
                return updatedResident[0];
            }

            throw new KeyNotFoundException($"Resident with Id of {resident.Id} was not found.");
        }

        public static ResidentResource ResidentLogin(IDbConnection db, string email, string password)
        {
            string sp = "dbo.find_resident";

            DynamicParameters prm = new DynamicParameters();

            prm.Add("@email_address", email);

            var residentProfile = DbStore.LoadData<ResidentResource>(db, sp, prm);

            if(residentProfile != null && residentProfile.Count == 1)
            {
                ResidentResource profile = residentProfile[0];

                bool password_hash = Encryption.VerifyEnhancePasswordWithBcrypt(profile.Password_Hash, password);

                if (password_hash)
                {
                    return profile;
                }

                throw new Exception("Invalid Credential");
            }

            throw new Exception("Something went wrong");
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
