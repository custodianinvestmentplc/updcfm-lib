using Custodian.Properties.Estate.Services.Abstraction;
using Custodian.Properties.Estates.Domain.Dto;
using Custodian.Properties.Estates.Domain.Entities;
using Custodian.Properties.Estates.Helpers.Domains;
using Custodian.Properties.Estates.Helpers.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.Properties.Estates.Services.Implementation
{
    public class AdminServices : IAdminServices
    {
        private readonly IDbConnection _db;

        public AdminServices(string dbconnectionString)
        {
            _db = Database.Connect(dbconnectionString);
        }
        public Resident CreateResident(ResidentDto resident)
        {
            Resident newResident = AdminHelper.CreateResident(_db, resident);

            return newResident;
        }

        public Staff Login(string email, string password)
        {
            var isAuth = AdminHelper.Login(_db, email, password);

            return isAuth;
        }

        public StaffDto CreateStaffProfile(StaffDto staff, string password)
        {
            var newStaff = AdminHelper.CreateStaffProfile(_db, staff, password);

            return newStaff;
        }
    }
}
