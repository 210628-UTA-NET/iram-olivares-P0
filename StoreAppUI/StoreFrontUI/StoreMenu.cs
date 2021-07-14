using System;
using System.Threading;

namespace StoreAppUI
{
    public class StoreMenu : IMenu
    {
        public void CurrentMenu()
        {
            Console.WriteLine("==== Store Menu ====");
            Console.WriteLine("Select Option and Press Enter");
            Console.WriteLine("[0] Return to Main Menu");
            Console.WriteLine("[1] Add Customer");
            Console.WriteLine("[2] Show All Customers");
            Console.WriteLine("[3] Search For a Customer");
            Console.WriteLine("[4] Show Available Stores");
            Console.WriteLine("[5] Place an Order");
            Console.WriteLine("[6] Replenish Store Inventory");
            Console.Write("Enter Input: ");
        }

        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    return AvailableMenu.MainMenu;
                case "1":
                    return AvailableMenu.AddCustomer;
                case "2":
                    return AvailableMenu.ShowAllCustomers;
                case "3":
                    return AvailableMenu.SearchForCustomer;
                case "4":
                    return AvailableMenu.ShowAllStores;
                case "5":
                    return AvailableMenu.OrderSetup;
                case "6":
                    return AvailableMenu.ReplenishInventory;
                default:
                    Console.WriteLine("Invalid Input");
                    Thread.Sleep(1000);
                    return AvailableMenu.StoreMenu;
            }
        }
    }
}