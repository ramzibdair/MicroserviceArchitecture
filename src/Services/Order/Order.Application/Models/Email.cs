using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Models
{
    public class Email
    {
        public string To { set; get; }
        public string Body { set; get; }
        public string Subject { set; get; }
    }
}
