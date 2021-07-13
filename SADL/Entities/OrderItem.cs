using System;
using System.Collections.Generic;

#nullable disable

namespace SADL.Entities
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int? OrderItemOrderId { get; set; }
        public int? OrderItemProductId { get; set; }
        public int? OrderItemQuantity { get; set; }

        public virtual Order OrderItemOrder { get; set; }
        public virtual Product OrderItemProduct { get; set; }
    }
}
