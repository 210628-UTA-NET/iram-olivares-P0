using System;
using System.Collections.Generic;

namespace SAModels
{
    public class Order
    {
        List<LineItem> OrderItems { get; set; }
        public string OrderAddress { get; set; }
        public double Price { get; set; }
    }
}