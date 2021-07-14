using SAModels;
using SABL;
using System;
using System.Collections.Generic;

namespace StoreAppUI
{
    public class ShowCustomerOrders : IMenu
    {
        private ICustomerBL _customerBL;
        private IOrderBL _orderBL;
        public ShowCustomerOrders(ICustomerBL p_customerBL, IOrderBL p_orderBL)
        {
            _customerBL = p_customerBL;
            _orderBL = p_orderBL;
        }
        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();
            Customer checkCustomer = new Customer();

            switch(input)
                {
                    case "0":
                        return AvailableMenu.CustomerPortal;

                    case "1":
                        if (MenuFactory.chosenCustomer == null)
                        {
                            Console.WriteLine("Please Enter a Customer Email");
                            Console.Write("Enter Any Key to Return: ");
                            Console.ReadLine();
                            return AvailableMenu.ShowCustomerOrders;
                        }

                        List<Order> getOrders = _orderBL.GetCustomerOrders(MenuFactory.tempCustomer);

                        if (getOrders.Count == 0)
                        {
                            Console.WriteLine("Customer Has Not Placed Any Orders!");
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

                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();

                        return AvailableMenu.StoreMenu;

                    case "a" or "A":
                        Console.Write("Enter Customer Email: ");
                        input = Console.ReadLine();
                        checkCustomer = _customerBL.GetOneCustomer(input);

                        if (checkCustomer == null)
                        {
                            Console.WriteLine("Please Enter an Existing Customer's Email");
                            Console.Write("Enter Any Key to Return: ");
                            Console.ReadLine();
                            return AvailableMenu.ShowCustomerOrders;
                        }

                        MenuFactory.chosenCustomer = input;
                        MenuFactory.tempCustomer = checkCustomer;
                        return AvailableMenu.ShowCustomerOrders;

                    default:
                        Console.WriteLine("Invalid Input");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.ShowCustomerOrders;
                }
        }

        public void CurrentMenu()
        {
            Console.WriteLine("[0] Return to Customer Portal");
            Console.WriteLine("[1] View Customer Order History (Field Must Be Filled Below");
            Console.WriteLine("[A] Customer Email: " + MenuFactory.chosenCustomer);
            Console.Write("Enter Input: ");
        }
    }
}