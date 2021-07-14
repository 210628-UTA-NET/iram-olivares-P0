using System;
using System.Collections.Generic;
using SABL;
using SAModels;

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
            Console.WriteLine("Enter Any Input to Return to Customer Portal");
            Console.ReadLine();
            return AvailableMenu.CustomerPortal;
        }

        public void CurrentMenu()
        {
            StoreFront chosenStore = _storeBL.GetOneStore(MenuFactory.chosenStore);
            List<LineItem> inventory = _storeBL.ViewInventory(chosenStore);
            Console.WriteLine($"{chosenStore.Name}'s Inventory");

            foreach(LineItem item in inventory)
            {
                Console.WriteLine(item);
            }
        }
    }
}