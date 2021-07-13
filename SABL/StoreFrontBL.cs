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

        public StoreFront GetOneStore(int p_storeID)
        {
            return _storeRepo.GetOneStore(p_storeID);
        }
        public List<LineItem> ReplenishInventory(StoreFront p_store, LineItem p_item, int p_amount)
        {
            return _storeRepo.ReplenishInventory(p_store, p_item, p_amount);
        }

        public List<LineItem> ViewInventory(StoreFront p_store)
        {
            return _storeRepo.ViewInventory(p_store);
        }
    }
}