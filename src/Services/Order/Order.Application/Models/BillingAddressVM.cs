using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Models
{
    public class BillingAddressVM
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string EmailAddress { get;  set; }
        public string AddressLine { get;  set; }
        public string Country { get;  set; }
        public string State { get;  set; }
        public string ZipCode { get;  set; }

    }
}
