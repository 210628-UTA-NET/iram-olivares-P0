using System;
using System.Threading;
using SAModels;
using SABL;

namespace StoreAppUI
{
    public class AddCustomer : IMenu
    {
        // This Customer object will contain information about a customer to be added
        private static Customer _newCustomer = new Customer();
        private static string _checker;

        // Interface type to easily interchange which database will be used to save data
        private ICustomerBL _customerBL;
        public AddCustomer(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }

        // sets the global _newCustomer to blank so information doesn't show where it is not needed
        public void ResetCustomer()
        {
            _newCustomer.Name = "";
            _newCustomer.Address = "";
            _newCustomer.Email = "";
            _newCustomer.Phone = "";
        }
        public void CurrentMenu()
        {
            Console.WriteLine("==== Add Customer ====");
            Console.WriteLine("Select Option and Press Enter");
            Console.WriteLine("[0] Return to Store Menu Without Saving");
            Console.WriteLine("[1] Add Customer to List (All Fields Below Must Be Filled)");
            Console.WriteLine("[A] Name: "+_newCustomer.Name);
            Console.WriteLine("[B] Address: "+_newCustomer.Address);
            Console.WriteLine("[C] Email: "+_newCustomer.Email);
            Console.WriteLine("[D] Phone Number: "+_newCustomer.Phone);
        }

        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    this.ResetCustomer();
                    return AvailableMenu.StoreMenu;
                case "1":
                    _customerBL.AddCustomer(_newCustomer);
                    this.ResetCustomer();
                    return AvailableMenu.AddCustomer;
                case "a" or "A" :
                    _checker = Console.ReadLine();
                    _newCustomer.Name = _checker;
                    return AvailableMenu.AddCustomer;
                case "b" or "B" :
                    _checker = Console.ReadLine();
                    _newCustomer.Address = _checker;
                    return AvailableMenu.AddCustomer;
                case "c" or "C" :
                    _checker = Console.ReadLine();
                    _newCustomer.Email = _checker;
                    return AvailableMenu.AddCustomer;
                case "d" or "D" :
                    _checker = Console.ReadLine();
                    _newCustomer.Phone = _checker;
                    return AvailableMenu.AddCustomer;
                default:
                    Console.WriteLine("Invalid Input");
                    Thread.Sleep(1000);
                    return AvailableMenu.AddCustomer;
            }
        }
    }
}