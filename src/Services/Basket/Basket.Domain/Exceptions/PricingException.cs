using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Domain.Exceptions
{
    internal class PricingException : Exception
    {
        public PricingException(string msg) : base(msg) { }
    }
}
