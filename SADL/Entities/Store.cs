using System;
using System.Collections.Generic;

#nullable disable

namespace SADL.Entities
{
    public partial class Store
    {
        public Store()
        {
            LineItems = new HashSet<LineItem>();
            Orders = new HashSet<Order>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
