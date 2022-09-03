using Order.Domain.Abstraction;
using Order.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class Order : EntityBase, IAggregateRoot
    {
        private Order() { }
        public Order(List<Product> products,BillingAddress billingAddress,Payment payment,string userName)
        {
            UserName = userName;
            Products = new List<Product>();
            AddProducts(products);
            BillingAddress = new BillingAddress(
                                                billingAddress.FirstName, billingAddress.LastName, 
                                                billingAddress.EmailAddress,billingAddress.AddressLine,
                                                billingAddress.Country, billingAddress.State, 
                                                billingAddress.ZipCode);
            Payment = new Payment(payment.CardName, payment.CardNumber, payment.Expiration, payment.CVV, payment.PaymentMethod);
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

        private void AddProducts(List<Product> products)
        {
            foreach(var product in products)
            {
                Products.Add(new Product() 
                {
                    Count = product.Count,
                    Id = product.Id,
                    Name = product.Name,
                    ImageFile = product.ImageFile,
                    Price = product.Price,
                    Summary = product.Summary
                });
            }
        }
    }
}
