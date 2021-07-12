using System;
using System.Collections.Generic;

namespace SAModels
{
    public class StoreFront
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<LineItem> Inventory { get; set; }
        public List<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"==================\nName: {Name}\nAddress: {Address}\n==================";
        }
    }
}