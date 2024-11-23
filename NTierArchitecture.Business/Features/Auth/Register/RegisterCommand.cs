using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Auth.Register
{
    public sealed record RegisterCommand(
        string Name,
        string Lastname,
        string Email,
        string UserName,
        string Password) : IRequest<Unit>;
}
