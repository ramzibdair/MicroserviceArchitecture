using System.Collections.Generic;

namespace Catalog.API.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
    }
}
