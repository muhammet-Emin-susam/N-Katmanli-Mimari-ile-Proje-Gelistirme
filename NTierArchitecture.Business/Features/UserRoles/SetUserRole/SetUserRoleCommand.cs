using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.UserRoles.SetUserRole
{
    public sealed record SetUserRoleCommand(
        Guid ID,
        Guid RoleID) : IRequest<Unit>;
}
