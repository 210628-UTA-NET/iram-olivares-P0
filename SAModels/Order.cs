using System;
using System.Collections.Generic;

namespace SAModels
{
    public class Order
    {
        public int ID { get; set; }
        List<LineItem> OrderItems { get; set; }
        public string OrderAddress { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Store Address: {OrderAddress}\nTotal Price: {Price}";
        }
    }
}