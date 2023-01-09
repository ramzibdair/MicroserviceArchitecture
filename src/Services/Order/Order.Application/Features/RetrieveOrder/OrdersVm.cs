using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.RetrieveOrder
{
    public  class OrdersVM
    {
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

    }
}
