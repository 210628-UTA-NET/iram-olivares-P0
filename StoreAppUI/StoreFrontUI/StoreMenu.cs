using System;

namespace StoreAppUI
{
    public class StoreMenu : IMenu
    {
        public void CurrentMenu()
        {
            Console.WriteLine(@"
  __  __                               ___         _        _ 
 |  \/  |__ _ _ _  __ _ __ _ ___ _ _  | _ \___ _ _| |_ __ _| |
 | |\/| / _` | ' \/ _` / _` / -_) '_| |  _/ _ \ '_|  _/ _` | |
 |_|  |_\__,_|_||_\__,_\__, \___|_|   |_| \___/_|  \__\__,_|_|
                       |___/                                  
");

            Console.WriteLine("[0] Return to Main Menu");
            Console.WriteLine("[1] Show All Customers");
            Console.WriteLine("[2] Replenish Store Inventory");
            Console.WriteLine("[3] Show A Store's Order History");
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
                    return AvailableMenu.ShowAllCustomers;
                case "2":
                    return AvailableMenu.ReplenishInventory;
                case "3":
                    return AvailableMenu.ShowStoreOrders;
                default:
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.StoreMenu;
            }
        }
    }
}