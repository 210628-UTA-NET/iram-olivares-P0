using System.Collections.Generic;
using SADL;
using SAModels;

namespace SABL
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private IStoreFrontRepo _storeRepo;

        public StoreFrontBL(IStoreFrontRepo p_storeRepo)
        {
            _storeRepo = p_storeRepo;
        }
        public List<StoreFront> GetAllStores()
        {
            return _storeRepo.GetAllStores();
        }

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