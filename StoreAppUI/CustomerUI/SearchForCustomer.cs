using System;
using SABL;
using SAModels;

namespace StoreAppUI
{
    public class SearchForCustomer : IMenu
    {
        
        private ICustomerBL _customerBL;

        public SearchForCustomer(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void CurrentMenu()
        {
            Console.WriteLine(@"
  ___                  _       ___        _                     
 / __| ___ __ _ _ _ __| |_    / __|  _ __| |_ ___ _ __  ___ _ _ 
 \__ \/ -_) _` | '_/ _| ' \  | (_| || (_-<  _/ _ \ '  \/ -_) '_|
 |___/\___\__,_|_| \__|_||_|  \___\_,_/__/\__\___/_|_|_\___|_|  
                                                                
");

            Console.WriteLine("[0] Return to Customer Portal");
            Console.Write("Insert Customer Email: ");
        }
        public AvailableMenu ChooseMenu()
        {
            string findMe = Console.ReadLine();
            if (findMe.Equals("0"))
            {
                return AvailableMenu.CustomerPortal;
            }

            Customer repoSearch = new Customer();

            try
            {
                repoSearch = _customerBL.GetOneCustomer(findMe);
                findMe.Equals(repoSearch.Email);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Customer Not Found!");
                Console.Write("Enter Any Key to Return: ");
                Console.ReadLine();

                return AvailableMenu.SearchForCustomer;
            }

            Console.WriteLine("==================");
            Console.WriteLine(repoSearch);
            Console.WriteLine("==================");
            Console.Write("Enter Any Key to Return: ");
            Console.ReadLine();
            return AvailableMenu.CustomerPortal;
        }
    }
}