﻿using System.Collections.Generic;

namespace EventBus.Messages.Events
{
   public class BasketCheckoutEvent : BaseEvent
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductItem> Items { get; set; } = new List<ProductItem>();

    }

    public class ProductItem
    {
        public int Quantity { get; set; }
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
