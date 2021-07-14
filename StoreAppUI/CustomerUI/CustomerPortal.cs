using System;

namespace StoreAppUI
{
    public class CustomerPortal : IMenu
    {
        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();

            switch(input)
            {
                case "0":
                    return AvailableMenu.MainMenu;
                case "1":
                    return AvailableMenu.AddCustomer;
                case "2":
                    return AvailableMenu.SearchForCustomer;
                case "3":
                    return AvailableMenu.OrderSetup;
                case "4":
                    return AvailableMenu.ShowCustomerOrders;
                case "5":
                    return AvailableMenu.ShowAllStores;
                default:
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.CustomerPortal;
            }
        }

        public void CurrentMenu()
        {
            Console.WriteLine(@"
   ___        _                       ___         _        _ 
  / __|  _ __| |_ ___ _ __  ___ _ _  | _ \___ _ _| |_ __ _| |
 | (_| || (_-<  _/ _ \ '  \/ -_) '_| |  _/ _ \ '_|  _/ _` | |
  \___\_,_/__/\__\___/_|_|_\___|_|   |_| \___/_|  \__\__,_|_|
                                                             
");
            Console.WriteLine("[0] Return to Main Menu");
            Console.WriteLine("[1] Add Your Account");
            Console.WriteLine("[2] Search For Your Account");
            Console.WriteLine("[3] Place an Order");
            Console.WriteLine("[4] View Order History");
            Console.WriteLine("[5] Show Available Stores and Their Inventories");
            Console.Write("Enter Input: ");
        }
    }
}