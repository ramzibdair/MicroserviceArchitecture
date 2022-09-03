
using Order.Application.Models;
using System;
using System.Collections.Generic;

namespace Order.Application.Features.CreateOrder
{
    public class CreateOrderVM
    {
        public CreateOrderVM()
        {
            Products = new List<ProductVM>();
            BillingAddress = new BillingAddressVM();
            Payment = new PaymentVM();
        }
        public int Id { set; get; }
        public DateTime CreatedOn{ set; get;  }

        public List<ProductVM> Products { get; }
        public BillingAddressVM BillingAddress { get; }
        public PaymentVM Payment { get; }
    }
}
