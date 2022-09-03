using Order.Domain.Abstraction;
using System.Collections.Generic;

namespace Order.Domain.ValueObjects
{
    public class BillingAddress : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string AddressLine { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public BillingAddress() { }

        public BillingAddress(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addressLine;
            Country = country;
            State = state;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
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
