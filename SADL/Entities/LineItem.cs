using System;
using System.Collections.Generic;

#nullable disable

namespace SADL.Entities
{
    public partial class LineItem
    {
        public int LineItemId { get; set; }
        public int? LineItemStoreId { get; set; }
        public int? LineItemProductId { get; set; }
        public int? LineItemQuantity { get; set; }

        public virtual Product LineItemProduct { get; set; }
        public virtual Store LineItemStore { get; set; }
    }
}
