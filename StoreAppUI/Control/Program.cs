// StoreApp UI Functionalities:
// - Add Customer
// - Search for a Customer
// - View Store Front Inventory
// - Place Order
// - View Customer and Store Order History
// - Replenish Store Inventory

using System;

namespace StoreAppUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // storeMenu will store which menu the user is currently accessing
            // The interface type is used because all possible menus will implement IMenu
            IMenu storeMenu = new MainMenu();
            // loop will be used to loop through the program, if false at any time, the application will be closed.
            bool loop = true;
            // currentMenu will be one of the possible menus that can be accessed (options found in IMenu interface)
            // Set to MainMenu at the beginning of the program
            AvailableMenu currentMenu = AvailableMenu.MainMenu;
            // Factory will help with code readability
            IMenuFactory menuFactory = new MenuFactory();

            
            while (loop)
            {
                Console.Clear();
                // output the UI depending on which menu is currently selected
                storeMenu.CurrentMenu();
                // Ask the user for input that will determine the next menu to be chosen
                currentMenu = storeMenu.ChooseMenu();

                switch (currentMenu)
                {
                    case AvailableMenu.MainMenu:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.MainMenu);
                        break;
                    // Will Exit the Application
                    case AvailableMenu.ExitApp:
                        loop = false;
                        break;
                    case AvailableMenu.StoreMenu:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.StoreMenu);
                        break;
                    case AvailableMenu.AddCustomer:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.AddCustomer);
                        break;
                    case AvailableMenu.ShowAllCustomers:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.ShowAllCustomers);
                        break;
                    case AvailableMenu.SearchForCustomer:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.SearchForCustomer);
                        break;
                    case AvailableMenu.ShowAllStores:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.ShowAllStores);
                        break;
                    case AvailableMenu.ShowStoreInventory:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.ShowStoreInventory);
                        break;
                    case AvailableMenu.OrderSetup:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.OrderSetup);
                        break;
                    case AvailableMenu.OrderItem:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.OrderItem);
                        break;
                    case AvailableMenu.ConfirmOrder:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.ConfirmOrder);
                        break;
                    case AvailableMenu.ReplenishInventory:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.ReplenishInventory);
                        break;
                    case AvailableMenu.ShowStoreOrders:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.ShowStoreOrders);
                        break;
                    case AvailableMenu.ShowCustomerOrders:
                        storeMenu = menuFactory.GetMenu(AvailableMenu.ShowCustomerOrders);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("Application Closing, Thank You for Using!");
        }
    }
}