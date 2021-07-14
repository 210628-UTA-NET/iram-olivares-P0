using System.Collections.Generic;

namespace SAModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Order> CustomerOrders { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nAddress: {Address}\nEmail: {Email}\nPhone: {Phone}";
        }
    }
}