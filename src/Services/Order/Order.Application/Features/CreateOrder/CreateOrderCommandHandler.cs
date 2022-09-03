using MediatR;
using Microsoft.Extensions.Logging;
using Order.Domain.Abstraction;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Features.CreateOrder
{
   public  class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderVM>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ILogger<CreateOrderCommandHandler> logger = null)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<CreateOrderVM> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new System.Exception();
        }
    }
}
