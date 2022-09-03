using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderVM>
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        // BillingAddress
    }
}
