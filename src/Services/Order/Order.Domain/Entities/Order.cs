using Order.Domain.Abstraction;
using Order.Domain.DomainEvents;
using Order.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Order.Domain.Errors.DomainErrors;

namespace Order.Domain.Entities
{
    public class Order : AggregateRoot
    {
        //private Order() { }
        private Order(List<Product> products,BillingAddress billingAddress,Payment payment,string userName)
        {
            UserName = userName;
            Products = new List<Product>();
            AddProducts(products);
            BillingAddress = billingAddress;
            //BillingAddress =  BillingAddress.Create(
            //                                    billingAddress.FirstName, billingAddress.LastName, 
            //                                    billingAddress.EmailAddress,billingAddress.AddressLine,
            //                                    billingAddress.Country, billingAddress.State, 
            //                                    billingAddress.ZipCode);
            //Payment = Payment.Create(payment.CardName, payment.CardNumber, payment.Expiration, payment.CVV, payment.PaymentMethod);
            Payment = payment;
        }
        public string UserName { get; }
        public decimal TotalPrice {
            get 
            {
                return Products.Count() > 0 ? this.Products.Sum(p => p.TotalPrice) : 0;
            }
        }
        public IList<Product> Products { get; }
        public BillingAddress BillingAddress { get; }
        public Payment Payment { get;  }

        public static Order Create(List<Product> products, BillingAddress billingAddress, Payment payment, string userName)
        {
          var order = new Order(products, billingAddress, payment, userName);
            RaiseEvent(new OrderCreatedDomainEvent(order.UserName, order.Id)); 
            return order;
        }
        public Order Checkout() 
        {
            //IOderRepository.Insert(this)
            RaiseEvent(new OrderCreatedDomainEvent(UserName, Id)); //TODO move to domain manager
            return this;
        }

        private void AddProducts(List<Product> products)
        {
            foreach(var product in products)
            {
                Products.Add(new Product() 
                {
                    Count = product.Count,
                    Name = product.Name,
                    ImageFile = product.ImageFile,
                    Price = product.Price,
                    Summary = product.Summary
                });
            }
        }
    }
}
