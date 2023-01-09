using Order.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.ValueObjects
{
    public class Payment: ValueObject
    {

        public static Payment Create(string cardName, string cardNumber, string expiration, string cVV, int paymentMethod)
        {
            //TODO : write your constrain 
            return new Payment( cardName,  cardNumber,  expiration,  cVV,  paymentMethod);
        }
        private Payment(string cardName, string cardNumber, string expiration, string cVV, int paymentMethod)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            CVV = cVV;
            PaymentMethod = paymentMethod;
        }

        public string CardName { get; private set; }
        public string CardNumber { get; private set; }
        public string Expiration { get; private set; }
        public string CVV { get; private set; }
        public int PaymentMethod { get; private set; }


        protected override IEnumerable<object> GetAtomicValue()
        {
            yield return CardName;
            yield return CardNumber;
            yield return Expiration;
            yield return CVV;
            yield return PaymentMethod;
        }
    }
}
