using Custodian.Properties.Estates.Domain.Dto;
using Custodian.Properties.Estates.Domain.Entities;
using Custodian.Properties.Estates.Domain.Resources;
using Custodian.Properties.Estates.Helpers.Services;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.Properties.Estates.Helpers.Domains
{
    public static class AdminHelper
    {
        public static Resident CreateResident(IDbConnection db, ResidentDto resident)
        {
            string sp = "dbo.create_resident";
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@Id", Guid.NewGuid());
            prm.Add("@FirstName", resident.FirstName);
            prm.Add("@LastName", resident.LastName);
            prm.Add("@UnitId", "1");

            prm.Add("@residentId", dbType: DbType.String, direction: ParameterDirection.ReturnValue);

            DbStore.SaveData(db, sp, prm);

            var residentId = prm.Get<int>("@residentId");

            foreach(var email in resident.Contact.email)
            {
                string spContact = "dbo.create_resident_contact";

                DynamicParameters residentEmail = new DynamicParameters();

                residentEmail.Add("@residentId", residentId);
                residentEmail.Add("@value", email);
                residentEmail.Add("@type", "EMAIL");

                DbStore.SaveData(db, spContact, residentEmail);
            }

            foreach(var phone in resident.Contact.phoneNumber)
            {
                string spContact = "dbo.create_resident_contact";

                DynamicParameters residentPhone = new DynamicParameters();

                residentPhone.Add("@residentId", residentId);
                residentPhone.Add("@value", phone);
                residentPhone.Add("@type", "PHONE");

                DbStore.SaveData(db, spContact, residentPhone);
            }

            DynamicParameters fr = new DynamicParameters();

            fr.Add("@email_address", resident.Contact.email[0]);

           var newResident = DbStore.LoadData<Resident>(db, "dbo.find_resident", fr);

            if(newResident != null && newResident.Count == 1)
            {
                return newResident[0];
            }
            else
            {
                throw new Exception("Counld not create new resident, try again");
            }
        }

        public static Staff Login(IDbConnection db, string email, string password)
        {
            try
            {
                string sp = "dbo.find_staff";

                DynamicParameters prm = new DynamicParameters();

                prm.Add("@email", email);

                var lst = DbStore.LoadData<Staff>(db, sp, prm);

                if (lst != null && lst.Count == 1)
                {

                    if (Encryption.VerifyEnhancePasswordWithBcrypt(lst[0].password, password))
                    {

                        return lst[0];

                    }

                }

                throw new Exception($"No staff found with {email}.");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static StaffDto CreateStaffProfile(IDbConnection db, StaffDto staff, string password)
        {
            try
            {
                string sp = "dbo.create_staff_profile";

                string hashPassword = Encryption.EnhanceHashPasswordWithBcrypt(password);

                DynamicParameters prm = new DynamicParameters();

                prm.Add("@id", Guid.NewGuid());
                prm.Add("@first_name", staff.first_name);
                prm.Add("@last_name", staff.last_name);
                prm.Add("@email", staff.email);
                prm.Add("@phone_number", staff.phone_number);
                prm.Add("@password", hashPassword);

                DbStore.SaveData(db, sp, prm);

                return staff;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
