using System.Collections.Generic;
using SAModels;

namespace SABL
{
    public class StoreFront : IStoreFrontBL
    {
        public void ReplenishInventory(StoreFront p_store, LineItem p_item, int p_amount)
        {
            throw new System.NotImplementedException();
        }

        public List<LineItem> ViewInventory(StoreFront p_store)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> ViewStoreOrderHistory(StoreFront p_store)
        {
            throw new System.NotImplementedException();
        }
    }
}