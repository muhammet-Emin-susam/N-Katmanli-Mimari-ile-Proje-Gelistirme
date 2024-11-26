using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.UserRoles.SetUserRole
{
    internal sealed class SetUserRoleCommandHandler : IRequestHandler<SetUserRoleCommand, Unit>
    {
        private readonly IUserRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SetUserRoleCommandHandler(IUserRoleRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SetUserRoleCommand request, CancellationToken cancellationToken)
        {
            var checkIsRoleExists = await _repository.AnyAsync(p => p.AppUserID == request.ID && p.AppRoleID == request.RoleID, cancellationToken);
            if (checkIsRoleExists)
            {
                throw new ArgumentException("Kullanıcı bu role zaten sahip");
            }

            UserRole userRole = new()
            {
                AppRoleID = request.RoleID,
                AppUserID = request.ID
            };
            await _repository.AddAsync(userRole,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
