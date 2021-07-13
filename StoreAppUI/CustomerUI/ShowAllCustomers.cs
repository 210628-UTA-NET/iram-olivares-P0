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

            Console.Write("Return to Store Menu With Any Key: ");
        }

        public AvailableMenu ChooseMenu()
        {
            Console.ReadLine();
            return AvailableMenu.StoreMenu;
        }
    }
}