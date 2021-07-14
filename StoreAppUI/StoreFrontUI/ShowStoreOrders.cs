using SAModels;
using SABL;
using System;
using System.Threading;
using System.Collections.Generic;

namespace StoreAppUI
{
    public class ShowStoreOrders : IMenu
    {
        private IStoreFrontBL _storeBL;
        private IOrderBL _orderBL;

        public ShowStoreOrders(IStoreFrontBL p_storeBL, IOrderBL p_orderBL)
        {
            _storeBL = p_storeBL;
            _orderBL = p_orderBL;
        }
        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();
            StoreFront checkStore = new StoreFront();
            switch(input)
            {
                case "0":
                    return AvailableMenu.StoreMenu;

                case "1":
                    if (MenuFactory.chosenStore == 0)
                    {
                        Console.WriteLine("Please Enter a Store ID");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.ShowStoreOrders;
                    }

                    List<Order> getOrders = new List<Order>();
                    getOrders = _orderBL.GetStoreOrders(MenuFactory.tempStore);

                    if (getOrders.Count == 0)
                    {
                        Console.WriteLine("Store Has No Orders!");
                        Console.Write("Enter Any Key to Return to Store Menu: ");
                        Console.ReadLine();
                        return AvailableMenu.StoreMenu;
                    }

                    foreach(Order order in getOrders)
                    {
                        Console.WriteLine("==================");
                        Console.WriteLine(order);
                        Console.WriteLine("==================");
                    }

                    Console.Write("Enter Any Key to Return to Store Menu: ");
                    Console.ReadLine();

                    return AvailableMenu.StoreMenu;

                case "a" or "A":
                Console.Write("Enter Store ID Number: ");
                    input = Console.ReadLine();
                    try
                    {
                        MenuFactory.chosenStore = Int32.Parse(input);
                    }
                    catch(System.Exception)
                    {
                        Console.WriteLine("Please Enter an Existing Store ID");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.ShowStoreOrders;
                    }
                    checkStore = _storeBL.GetOneStore(MenuFactory.chosenStore);
                    if(checkStore == null)
                    {
                        Console.WriteLine("Please Enter an Existing Store ID");
                        MenuFactory.chosenStore = 0;
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.ShowStoreOrders;
                    }
                    MenuFactory.tempStore = checkStore;
                    return AvailableMenu.ShowStoreOrders;

                default:
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.ShowStoreOrders;
            }
        }

        public void CurrentMenu()
        {
            Console.WriteLine("==== View Store Order History ====");
            Console.WriteLine("[0] Return to Store Menu");
            Console.WriteLine("[1] View Store Order History (Field Must Be Filled Below)");
            if (MenuFactory.chosenStore == 0)
            {
                Console.WriteLine("[A] Store ID Number: ");
            }
            else
            {
                Console.WriteLine("[A] Store ID Number: " + MenuFactory.chosenStore);
            }
            Console.Write("Enter Input: ");
        }
    }
}