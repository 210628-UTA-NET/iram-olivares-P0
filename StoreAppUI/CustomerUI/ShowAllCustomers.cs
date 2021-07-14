using System;
using System.Collections.Generic;
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
            Console.WriteLine(@"
    _   _ _    ___        _                        
   /_\ | | |  / __|  _ __| |_ ___ _ __  ___ _ _ ___
  / _ \| | | | (_| || (_-<  _/ _ \ '  \/ -_) '_(_-<
 /_/ \_\_|_|  \___\_,_/__/\__\___/_|_|_\___|_| /__/
                                                   
");

            List<Customer> customers = _customerBL.GetAllCustomers();

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
                Console.WriteLine("==================");
            }
        }

        public AvailableMenu ChooseMenu()
        {
            Console.Write("Enter Any Key to Return: ");
            Console.ReadLine();
            return AvailableMenu.StoreMenu;
        }
    }
}