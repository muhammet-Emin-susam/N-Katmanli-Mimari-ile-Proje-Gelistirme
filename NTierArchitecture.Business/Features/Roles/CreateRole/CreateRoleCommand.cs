﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Roles.CreateRole
{
    public sealed record CreateRoleCommand(
        string Name) : IRequest<Unit>;
}
