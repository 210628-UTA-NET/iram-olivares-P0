using System;
using System.Collections.Generic;

#nullable disable

namespace SADL.Entities
{
    public partial class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int OrderId { get; set; }
        public int? OrderCustomerId { get; set; }
        public int? OrderStoreId { get; set; }
        public string OrderLocation { get; set; }
        public decimal? OrderPrice { get; set; }

        public virtual Customer OrderCustomer { get; set; }
        public virtual Store OrderStore { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
