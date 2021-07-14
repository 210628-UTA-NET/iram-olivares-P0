using System.Collections.Generic;
using Entity = SADL.Entities;
using SAModels;
using System.Linq;

namespace SADL
{
    public class OrderRepo : IOrderRepo
    {
        private Entity.ieoDemoDBContext _context;

        public OrderRepo(Entity.ieoDemoDBContext p_context)
        {
            _context = p_context;
        }
        public List<Order> GetCustomerOrders(Customer p_customer)
        {
            List<Order> customerOrder = _context.Orders.Select(order => new Order()
            {
                ID = order.OrderId,
                Price = (double)order.OrderPrice
            }).ToList();

            return customerOrder;
        }

        public List<Order> GetStoreOrders(StoreFront p_store)
        {
            List<Order> storeOrder = _context.Orders.Select(order => new Order()
            {
                ID = (int)order.OrderStoreId,
                OrderAddress = order.OrderLocation,
                Price = (double)order.OrderPrice
            }).Where(check => p_store.StoreID == check.ID).ToList();

            return storeOrder;
        }

        public Order PlaceOrder(Customer p_customer, StoreFront p_store, Order p_order)
        {
            _context.Orders.Add(new Entity.Order()
            {
                OrderCustomerId = p_customer.Id,
                OrderStoreId = p_store.StoreID,
                OrderPrice = (decimal)p_order.Price,
                OrderLocation = p_store.Address
            });

            _context.SaveChanges();
            return p_order;
        }
    }
}