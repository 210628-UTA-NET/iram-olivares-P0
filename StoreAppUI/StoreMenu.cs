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
                default:
                    Console.WriteLine("Invalid Input");
                    Thread.Sleep(1000);
                    return AvailableMenu.StoreMenu;
            }
        }
    }
}