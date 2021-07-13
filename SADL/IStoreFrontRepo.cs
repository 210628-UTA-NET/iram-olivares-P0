using System.Collections.Generic;
using SAModels;

namespace SADL
{
    public interface IStoreFrontRepo
    {
        /// <summary>
        /// Allows user to recieve a list of all available stores
        /// </summary>
        /// <returns> Will return a list of available stores </returns>
        List<StoreFront> GetAllStores();

        /// <summary>
        /// Retrieves a store from the database
        /// </summary>
        /// <param name="p_storeID"> ID as a parameter to extract the correct store </param>
        /// <returns> Will return a store from the database </returns>
        StoreFront GetOneStore(int p_storeID);

        /// <summary>
        /// Allows the user to view a store's inventory
        /// </summary>
        /// <param name="p_storeID"> Takes in a store's ID as a parameter </param>
        /// <returns> Will return a list of the store's available items </returns>
        List<LineItem> ViewInventory(StoreFront p_store);

        /// <summary>
        /// Retrieves an Item from a store's inventory
        /// </summary>
        /// <param name="p_itemName"> Name of the item requested </param>
        /// <param name="p_store"> Specified store to search through </param>
        /// <returns> Searches through the database for an item and store match </returns>
        LineItem GetOneItem(string p_itemName, StoreFront p_store);

        /// <summary>
        /// Allows the user to replenish an item in a store
        /// </summary>
        /// <param name="p_store"> Takes in a store that needs resupply </param>
        /// <param name="p_item"> Takes in the item to be replenished </param>
        /// <param name="p_amount"> The number of items to be added </param>
        /// <returns> Will return the newly replenished inventory </returns>
        List<LineItem> ReplenishInventory(StoreFront p_store, LineItem p_item, int p_amount);
    }
}