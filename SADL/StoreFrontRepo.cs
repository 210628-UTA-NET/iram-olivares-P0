using System.Collections.Generic;
using Model = SAModels;
using Entity = SADL.Entities;
using System.Linq;
using SAModels;

namespace SADL
{
    public class StoreFrontRepo : IStoreFrontRepo
    {
        private Entity.ieoDemoDBContext _context;

        public StoreFrontRepo(Entity.ieoDemoDBContext p_context)
        {
            _context = p_context;
        }
        public List<Model.StoreFront> GetAllStores()
        {
            // Method Syntax Way
            return _context.Stores.Select(
                store => new Model.StoreFront()
                    {
                        StoreID = store.StoreId,
                        Name = store.StoreName,
                        Address = store.StoreAddress
                    }
            ).ToList();
        }

        public Model.StoreFront GetOneStore(int p_storeID)
        {
            return  _context.Stores.Select(
                store => new Model.StoreFront()
                    {
                        StoreID = store.StoreId,
                        Name = store.StoreName,
                        Address = store.StoreAddress
                    }
            ).Where(check => check.StoreID == p_storeID).SingleOrDefault();
        }

        public void ReplenishInventory(StoreFront p_store, LineItem p_item, int p_amount)
        {
            throw new System.NotImplementedException();
        }

        public List<LineItem> ViewInventory(StoreFront p_store)
        {
            var query = from item in _context.LineItems
                        join product in _context.Products on item.LineItemProductId equals product.ProductId
                        select new Model.LineItem { Item = product.ProductName, Quantity = (int)item.LineItemQuantity };

            return query.ToList();
        }

        public List<Order> ViewStoreOrderHistory(StoreFront p_store)
        {
            throw new System.NotImplementedException();
        }
    }
}