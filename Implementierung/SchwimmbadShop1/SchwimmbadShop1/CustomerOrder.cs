using System;
using System.Collections.Generic;

namespace SchwimmbadShop1
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public DateTime? Orderdate { get; set; }
        public decimal? TotalAmount { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
