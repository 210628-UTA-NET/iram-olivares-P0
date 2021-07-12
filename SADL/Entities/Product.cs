using System;
using System.Collections.Generic;

#nullable disable

namespace SADL.Entities
{
    public partial class Product
    {
        public Product()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
