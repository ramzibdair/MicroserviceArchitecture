using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.Extensions.Logging;
using Order.Application.Features.CreateOrder;
using System;
using System.Threading.Tasks;

namespace Order.API.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketCheckoutConsumer> _logger;

        public BasketCheckoutConsumer(IMediator mediator, IMapper mapper, ILogger<BasketCheckoutConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var commend = new CreateOrderCommand() { TotalPrice = context.Message.TotalPrice, UserName = context.Message.UserName };
            await _mediator.Send(commend);
            _logger.LogInformation("BasketCheckout event has been consumed successfully.");
        }
    }
}
