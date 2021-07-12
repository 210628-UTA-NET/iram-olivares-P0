using System;
using System.Collections.Generic;
using System.Threading;
using SABL;
using SAModels;

namespace StoreAppUI
{
    public class ShowAllCustomers : IMenu
    {
        private ICustomerBL _customerBL;
        public ShowAllCustomers(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void CurrentMenu()
        {
            Console.WriteLine("List of Customers");

            List<Customer> customers = _customerBL.GetAllCustomers();

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine("[0] Return to Store Menu");
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"[{customer.Id}] View {customer.Name}'s Placed Orders");
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
                    Console.WriteLine("Invalid Input");
                    Thread.Sleep(1000);
                    return AvailableMenu.ShowAllCustomers;
            }
        }
    }
}