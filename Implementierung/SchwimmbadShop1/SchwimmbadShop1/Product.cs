﻿using System;
using System.Collections.Generic;

namespace SchwimmbadShop1
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
