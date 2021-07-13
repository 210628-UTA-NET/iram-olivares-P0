using System;
using System.Threading;
using SAModels;
using SABL;

namespace StoreAppUI
{
    public class AddCustomer : IMenu
    {

        // Interface type to easily interchange which database will be used to save data
        private ICustomerBL _customerBL;
        public AddCustomer(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void CurrentMenu()
        {
            Console.WriteLine("==== Add Customer ====");
            Console.WriteLine("Select Option and Press Enter");
            Console.WriteLine("[0] Return to Store Menu Without Saving");
            Console.WriteLine("[1] Add Customer to List (All Fields Below Must Be Filled)");
            Console.WriteLine("[A] Name: "+MenuFactory.tempCustomer.Name);
            Console.WriteLine("[B] Address: "+MenuFactory.tempCustomer.Address);
            Console.WriteLine("[C] Email: "+MenuFactory.tempCustomer.Email);
            Console.WriteLine("[D] Phone Number: "+MenuFactory.tempCustomer.Phone);
        }

        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    MenuFactory.ResetParams(); 
                    return AvailableMenu.StoreMenu;
                case "1":
                    _customerBL.AddCustomer(MenuFactory.tempCustomer);
                    MenuFactory.ResetParams();
                    return AvailableMenu.AddCustomer;
                case "a" or "A" :
                    MenuFactory.checker = Console.ReadLine();
                    MenuFactory.tempCustomer.Name = MenuFactory.checker;
                    return AvailableMenu.AddCustomer;
                case "b" or "B" :
                    MenuFactory.checker = Console.ReadLine();
                    MenuFactory.tempCustomer.Address = MenuFactory.checker;
                    return AvailableMenu.AddCustomer;
                case "c" or "C" :
                    MenuFactory.checker = Console.ReadLine();
                    MenuFactory.tempCustomer.Email = MenuFactory.checker;
                    return AvailableMenu.AddCustomer;
                case "d" or "D" :
                    MenuFactory.checker = Console.ReadLine();
                    MenuFactory.tempCustomer.Phone = MenuFactory.checker;
                    return AvailableMenu.AddCustomer;
                default:
                    Console.WriteLine("Invalid Input");
                    Thread.Sleep(1000);
                    return AvailableMenu.AddCustomer;
            }
        }
    }
}