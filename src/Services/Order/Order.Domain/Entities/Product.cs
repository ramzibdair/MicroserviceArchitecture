using Order.Domain.Abstraction;

namespace Order.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; } = 1;
        public decimal TotalPrice => Price * Count;
    }
}
