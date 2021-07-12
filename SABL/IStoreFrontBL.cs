using System.Collections.Generic;
using SAModels;

namespace SABL
{
    /// <summary>
    /// Will handle all operations involving the Stores here
    /// Any operation that accesses the database will be received through the DL
    /// </summary>
    public interface IStoreFrontBL
    {
        /// <summary>
        /// Allows the user to view a store's inventory
        /// </summary>
        /// <param name="p_store"> Takes in a store as a parameter </param>
        /// <returns> Will return a list of the store's available items </returns>
        List<LineItem> ViewInventory(StoreFront p_store);

        /// <summary>
        /// Allows the user to replenish an item in a store
        /// </summary>
        /// <param name="p_store"> Takes in a store that needs resupply </param>
        /// <param name="p_item"> Takes in the item to be replenished </param>
        /// <param name="p_amount"> The number of items to be added </param>
        void ReplenishInventory(StoreFront p_store, LineItem p_item, int p_amount);

        /// <summary>
        /// Allows the user to view a store's order history
        /// </summary>
        /// <param name="p_store"> Takes in a store as a parameter </param>
        /// <returns> Will return a list of the store's orders </returns>
        List<Order> ViewStoreOrderHistory(StoreFront p_store);
    }
}