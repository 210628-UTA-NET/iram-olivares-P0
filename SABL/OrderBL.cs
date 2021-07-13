using System.Collections.Generic;
using SADL;
using SAModels;

namespace SABL
{
    public class OrderBL : IOrderBL
    {
        private IOrderRepo _orderRepo;

        public OrderBL(IOrderRepo p_orderRepo)
        {
            _orderRepo = p_orderRepo;
        }
        public List<Order> GetCustomerOrders(Customer p_customer)
        {
            return _orderRepo.GetCustomerOrders(p_customer);
        }

        public List<Order> GetStoreOrders(StoreFront p_store)
        {
            return _orderRepo.GetStoreOrders(p_store);
        }

        public Order PlaceOrder(Customer p_customer, StoreFront p_store, Order p_order)
        {
            return _orderRepo.PlaceOrder(p_customer, p_store, p_order);
        }
    }
}