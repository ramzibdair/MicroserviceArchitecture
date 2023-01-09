using Order.Domain.Abstraction;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Order.Domain.ValueObjects
{
    public class BillingAddress : ValueObject
    {
        public string FirstName { get;  }
        public string LastName { get;  }
        public string EmailAddress { get;  }
        public string AddressLine { get;}
        public string Country { get; }
        public string State { get; }
        public string ZipCode { get; }

        public static BillingAddress Create(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
        {
            //TODO : write your constrain 
            return new BillingAddress(firstName, lastName, emailAddress, addressLine, country, state, zipCode);
        }

        private BillingAddress(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addressLine;
            Country = country;
            State = state;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetAtomicValue()
        {
            yield return FirstName;
            yield return LastName;
            yield return EmailAddress;
            yield return AddressLine;
            yield return Country;
            yield return State;
             yield return ZipCode;
        }
    }
}
