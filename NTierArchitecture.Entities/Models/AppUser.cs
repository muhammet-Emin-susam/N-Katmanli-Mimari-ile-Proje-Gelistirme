﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Entities.Models
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
