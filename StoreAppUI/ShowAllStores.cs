using System;
using System.Collections.Generic;
using System.Threading;
using SABL;
using SAModels;

namespace StoreAppUI
{
    public class ShowAllStores : IMenu
    {
        private IStoreFrontBL _storeBL;
        public ShowAllStores(IStoreFrontBL p_store)
        {
            _storeBL = p_store;
        }
        public void CurrentMenu()
        {
            Console.WriteLine("List of Stores");

            List<StoreFront> stores = _storeBL.GetAllStores();

            foreach (StoreFront store in stores)
            {
                Console.WriteLine(store);
            }

            Console.WriteLine("[0] Return to Store Menu");
        }

        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();

            switch(input)
            {
                case "0":
                    return AvailableMenu.StoreMenu;
                default: 
                    Console.WriteLine("Invalid Input");
                    Thread.Sleep(1000);
                    return AvailableMenu.ShowAllStores;
            }
        }
    }
}