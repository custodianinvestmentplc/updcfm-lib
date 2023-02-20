using Custodian.Properties.Estates.Domain.Dto;
using Custodian.Properties.Estates.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.Properties.Estate.Services.Abstraction
{
    public interface IAdminServices
    {
        Resident CreateResident(ResidentDto resident);
        Staff Login(string email, string password);
        StaffDto CreateStaffProfile(StaffDto staff, string password);
    }
}
