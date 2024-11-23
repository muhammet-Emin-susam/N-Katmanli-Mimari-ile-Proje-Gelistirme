using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Entities.Abstractions
{
    public  interface IJwtProvider
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
