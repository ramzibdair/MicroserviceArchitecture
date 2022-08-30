using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disount.API.Entities
{
    public class Coupon
    {
        public int ID { set; get; }
        public string ProductName { set; get; }
        public string Description { set; get; }
        public int Amount { set; get; }

    }
}
