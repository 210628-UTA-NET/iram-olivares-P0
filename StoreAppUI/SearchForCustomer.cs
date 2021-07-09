using System;
using SABL;

namespace StoreAppUI
{
    public class SearchForCustomer : IMenu
    {
        // Search database for a customer with the name matching _findCustomer
        private string _findCustomer;
        
        private ICustomerBL _customerBL;

        public SearchForCustomer(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void CurrentMenu()
        {
            Console.WriteLine("==== Search For A Customer ====");
            Console.WriteLine("[0] Return to Store Menu");
            Console.Write("Insert Customer Name: ");
        }
        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();

            switch(input)
            {
                case "0":
                    return AvailableMenu.StoreMenu;
                default :
                    return AvailableMenu.SearchForCustomer;
            }
        }
    }
}