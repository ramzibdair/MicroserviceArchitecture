using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class OutboxMessage
    {
        public Guid Id { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime? ProcessOn { set; get; }
        public string Type { set; get; }
        public string Content { set; get; }
    }
}
