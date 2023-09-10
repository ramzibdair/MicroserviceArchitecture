using Basket.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basket.Domain.Entities
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
        public decimal Price { get; private set; }
        public decimal OriginalPrice { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }

           public void SetPrice(decimal originalPrice , decimal discountAmount)
        {
            if(originalPrice < 0 || discountAmount < 0 || (originalPrice - discountAmount) < 0) {
                throw new PricingException(Errors.PricingError);
            }
            OriginalPrice = originalPrice;
            DiscountAmount = discountAmount;
            Price = originalPrice - discountAmount;
        }
    }
}
