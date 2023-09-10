
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Catalog.Domain.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}
