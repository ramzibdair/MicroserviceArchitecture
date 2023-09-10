using MediatR;
using Microsoft.Extensions.Logging;
using Order.Application.Contracts.Infra;
using Order.Application.Models;
using Order.Domain.DomainEvents;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Features.CreateOrder
{
    internal class OrderCreatedDomainEventHandler : INotificationHandler<OrderCreatedDomainEvent>
    {
        private readonly IEmailSender _emailService;
        private readonly ILogger<OrderCreatedDomainEventHandler> _logger;

        public OrderCreatedDomainEventHandler(IEmailSender emailService, ILogger<OrderCreatedDomainEventHandler> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        public Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        private async Task SendMail(Domain.Entities.Order order)
        {
            
            var email = new Email() { To = "ramzi.bdair@gmail.com", Body = $"Order was created.", Subject = "Order was created" };

            try
            {
                await _emailService.Send(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
            }
        }
    }
}
