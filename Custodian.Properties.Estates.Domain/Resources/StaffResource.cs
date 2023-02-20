using Custodian.Properties.Estates.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.Properties.Estates.Domain.Resources
{
    public class StaffResource : Staff
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty; 
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public EstateResource Estate { get; set; } = new EstateResource();

    }
}
