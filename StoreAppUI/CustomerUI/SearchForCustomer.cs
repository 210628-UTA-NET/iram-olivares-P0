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
            Console.WriteLine("==== Search For A Customer ====");
            Console.WriteLine("[0] Return to Store Menu");
            Console.Write("Insert Customer Email: ");
        }
        public AvailableMenu ChooseMenu()
        {
            string findMe = Console.ReadLine();
            if (findMe.Equals("0"))
            {
                return AvailableMenu.StoreMenu;
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

            Console.WriteLine(repoSearch);
            Console.WriteLine("[0] Return to Store Menu");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    return AvailableMenu.OrderItem;
                default:
                    return AvailableMenu.StoreMenu;
            }
        }
    }
}