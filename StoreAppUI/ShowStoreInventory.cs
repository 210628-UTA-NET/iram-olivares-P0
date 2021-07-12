using System;
using SABL;

namespace StoreAppUI
{
    public class ShowStoreInventory : IMenu
    {
        private IStoreFrontBL _storeBL;

        public ShowStoreInventory(IStoreFrontBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public AvailableMenu ChooseMenu()
        {
            throw new System.NotImplementedException();
        }

        public void CurrentMenu()
        {
            
            Console.WriteLine("[0] Return to Store Menu");
        }
    }
}