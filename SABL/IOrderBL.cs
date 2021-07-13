using System.Collections.Generic;
using SAModels;

namespace SABL
{
    /// <summary>
    /// Any database access involving the Order table (and OrderItem) will belong here
    /// </summary>
    public interface IOrderBL
    {
        /// <summary>
        /// Allows a Customer to place an order at the specified store
        /// </summary>
        /// <param name="p_customer"> Customer input </param>
        /// <param name="p_store"> Store input </param>
        /// <returns> Returns the Order if successful, null otherwise </returns>
        Order PlaceOrder(Customer p_customer, StoreFront p_store, Order p_order);

        /// <summary>
        /// Allows user to view a Customer's orders
        /// </summary>
        /// <param name="p_customer"> Customer input </param>
        /// <returns> Returns the List of Orders if successful, null otherwise</returns>
        List<Order> GetCustomerOrders(Customer p_customer);

        /// <summary>
        /// Allows user to view a Store's orders
        /// </summary>
        /// <param name="p_store"> Store input </param>
        /// <returns> Returns the List of Orders if successful, null otherwise </returns>
        List<Order> GetStoreOrders(StoreFront p_store);
    }
}