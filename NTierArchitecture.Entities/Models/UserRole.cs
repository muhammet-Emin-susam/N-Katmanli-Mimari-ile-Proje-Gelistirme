using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Entities.Models
{
    public sealed class UserRole
    {
        public Guid AppUserID { get; set; }

        public AppUser AppUser { get; set; }
        public Guid AppRoleID { get; set; }

        public AppRole AppRole { get; set; }


    }
}
