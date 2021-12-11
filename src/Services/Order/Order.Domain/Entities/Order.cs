using Order.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class Order : EntityBase
    {
        private Order() { }
        public Order(string userName,
                     decimal totalPrice,
                     string firstName,
                     string lastName,
                     string emailAddress,
                     string addressLine,
                     string country,
                     string state,
                     string zipCode,
                     string cardName,
                     string cardNumber,
                     string expiration,
                     string cVV,
                     int paymentMethod)
        {
            UserName = userName;
            TotalPrice = totalPrice;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addressLine;
            Country = country;
            State = state;
            ZipCode = zipCode;
            CardName = cardName;
            CardNumber = CardNumber;
            Expiration = expiration;
            CVV = cVV;
            PaymentMethod = paymentMethod;

        }
        public string UserName { get; private set; }
        public decimal TotalPrice { get; private set; }

        // BillingAddress
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string AddressLine { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        // Payment
        public string CardName { get; private set; }
        public string CardNumber { get; private set; }
        public string Expiration { get; private set; }
        public string CVV { get; private set; }
        public int PaymentMethod { get; private set; }
    }
}
