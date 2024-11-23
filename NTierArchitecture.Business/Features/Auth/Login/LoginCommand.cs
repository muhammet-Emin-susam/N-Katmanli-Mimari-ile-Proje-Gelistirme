using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Auth.Login
{
    public sealed record LoginCommand(
        string UserNameOrEmail,
        string Password) : IRequest<LoginCommandResponse>;
}
