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
                MenuFactory.chosenCustomer = repoSearch.Id;
                findMe.Equals(repoSearch.Email);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Customer Not Found!");
                Thread.Sleep(1000);

                return AvailableMenu.SearchForCustomer;
            }

            Console.WriteLine(repoSearch);
            Console.WriteLine("[1] Place an Order");
            Console.WriteLine("Any Other Key to Return to Store Menu");
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