using System.Collections.Generic;
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
        public List<StoreFront> GetAllStores()
        {
            // Method Syntax Way
            return _context.Stores.Select(
                store => new StoreFront()
                    {
                        StoreID = store.StoreId,
                        Name = store.StoreName,
                        Address = store.StoreAddress
                    }
            ).ToList();
        }

        public double GetItemPrice(LineItem p_item)
        {
            var data = _context.Products.Where(check => p_item.Item == check.ProductName).SingleOrDefault();
            return (double)data.ProductPrice;
        }

        public LineItem GetOneItem(string p_itemName, StoreFront p_store)
        {
            // first get the list of items from the given store
            List<LineItem> itemList = this.ViewInventory(p_store);

            // search through the list for a matching item name
            foreach(LineItem item in itemList)
            {
                // if name matches, then return the item, otherwise null
                if (item.Item.Equals(p_itemName))
                {
                    return item;
                }
            }
            return null;
        }

        public StoreFront GetOneStore(int p_storeID)
        {
            return  _context.Stores.Select(store => new StoreFront()
                    {
                        StoreID = store.StoreId,
                        Name = store.StoreName,
                        Address = store.StoreAddress
                    })
                    .Where(check => check.StoreID == p_storeID).SingleOrDefault();
        }

        public List<LineItem> ReplenishInventory(StoreFront p_store, LineItem p_item, int p_amount)
        {
            // Get the corresponding item from the database
            var data = _context.LineItems.Where(item => item.LineItemId == p_item.ID).FirstOrDefault();
            
            // Remove it from the database to be updated later
            _context.LineItems.Remove(data);
            // Update LineItem and save changes to database
            Entity.LineItem replenish = new Entity.LineItem()
            {
                LineItemId = data.LineItemId,
                LineItemStoreId = data.LineItemStoreId,
                LineItemProductId = data.LineItemProductId,
                LineItemQuantity = data.LineItemQuantity + p_amount
            };
            
            if (data.LineItemQuantity > p_item.Quantity)
                {
                    replenish.LineItemQuantity = p_item.Quantity;
                }
  
            _context.LineItems.Add(replenish);
            _context.SaveChanges();

            // return the replenished inventory
            return this.ViewInventory(p_store);
            

        }

        public List<LineItem> ViewInventory(StoreFront p_store)
        {
            var filterStore = from store in _context.Stores
                        where store.StoreId == p_store.StoreID
                        select new {StoreID = store.StoreId};

            var inventory = from item in _context.LineItems
                        join store in filterStore on item.LineItemStoreId equals store.StoreID
                        join product in _context.Products on item.LineItemProductId equals product.ProductId
                        select new LineItem { ID = item.LineItemId, Item = product.ProductName, Quantity = (int)item.LineItemQuantity };

            return inventory.ToList();
        }
    }
}