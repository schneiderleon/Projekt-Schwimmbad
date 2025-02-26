using System;
using System.Collections.Generic;

namespace SchwimmbadShop1
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual CustomerOrder Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
