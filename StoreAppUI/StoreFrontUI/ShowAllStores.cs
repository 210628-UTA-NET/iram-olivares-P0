using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SABL;
using SAModels;

namespace StoreAppUI
{
    public class ShowAllStores : IMenu
    {
        private IStoreFrontBL _storeBL;
        public ShowAllStores(IStoreFrontBL p_storeBL)
        {
            _storeBL = p_storeBL;
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
            foreach (StoreFront store in stores)
            {
                Console.WriteLine($"[{store.StoreID}] View {store.Name}'s Inventory");
            }
        }

        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();

            switch(input)
            {
                case "0":
                    return AvailableMenu.StoreMenu;
                default: 
                    if (Regex.IsMatch(input, @"^[0-9]+$"))
                    {
                        MenuFactory.chosenStore = Int32.Parse(input);
                        return AvailableMenu.ShowStoreInventory;
                    }
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.ShowAllStores;
            }
        }
    }
}