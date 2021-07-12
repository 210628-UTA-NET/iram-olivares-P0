using System;
using System.Collections.Generic;
using SABL;
using SAModels;

namespace StoreAppUI
{
    public class ShowStoreInventory : IMenu
    {
        private IStoreFrontBL _storeBL;
        private int _chosenStore;

        public ShowStoreInventory(int p_chosenStore, IStoreFrontBL p_storeBL)
        {
            _chosenStore = p_chosenStore;
            _storeBL = p_storeBL;
        }
        public AvailableMenu ChooseMenu()
        {
            Console.WriteLine("Enter Any Input to Return to Store Menu");
            Console.ReadLine();
            return AvailableMenu.StoreMenu;
        }

        public void CurrentMenu()
        {
            StoreFront chosenStore = _storeBL.GetOneStore(_chosenStore);
            List<LineItem> inventory = _storeBL.ViewInventory(chosenStore);
            Console.WriteLine($"{chosenStore.Name}'s Inventory");

            foreach(LineItem item in inventory)
            {
                Console.WriteLine(item);
            }
        }
    }
}