using MediatR;

namespace NTierArchitecture.Entities.Events.User
{
    public sealed class SendRegisterEmail : INotificationHandler<UserDomainEvent>
    {
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
    }
}
