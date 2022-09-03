using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Models
{
    public class ProductVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; } = 1;
        public decimal TotalPrice => Price * Count;
    }
}
