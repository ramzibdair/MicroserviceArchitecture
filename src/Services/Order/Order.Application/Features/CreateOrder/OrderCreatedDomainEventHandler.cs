using MediatR;
using Order.Domain.DomainEvents;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Features.CreateOrder
{
    internal class OrderCreatedDomainEventHandler : INotificationHandler<OrderCreatedDomainEvent>
    {
        public Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
