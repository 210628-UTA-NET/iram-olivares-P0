using System;
using SABL;
using SAModels;
using System.Threading;

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
                Thread.Sleep(1000);

                return AvailableMenu.SearchForCustomer;
            }

            Console.WriteLine(repoSearch);
            Console.ReadLine();
            return AvailableMenu.SearchForCustomer;
        }
    }
}