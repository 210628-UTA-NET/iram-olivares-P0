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
            Console.Write("Enter Input: ");
        }

        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    return AvailableMenu.StoreMenu;

                case "1":
                    _customerBL.AddCustomer(MenuFactory.tempCustomer);
                    Console.WriteLine("Customer Successfully Added!");
                    Thread.Sleep(1000);
                    return AvailableMenu.StoreMenu;

                case "a" or "A" :
                    Console.Write("Enter Customer Name: ");
                    MenuFactory.checker = Console.ReadLine();
                    MenuFactory.tempCustomer.Name = MenuFactory.checker;
                    return AvailableMenu.AddCustomer;

                case "b" or "B" :
                    Console.Write("Enter Customer Address: ");
                    MenuFactory.checker = Console.ReadLine();
                    MenuFactory.tempCustomer.Address = MenuFactory.checker;
                    return AvailableMenu.AddCustomer;

                case "c" or "C" :
                    Console.Write("Enter Customer Email: ");
                    MenuFactory.checker = Console.ReadLine();
                    MenuFactory.tempCustomer.Email = MenuFactory.checker;
                    return AvailableMenu.AddCustomer;

                case "d" or "D" :
                    Console.Write("Enter Customer Phone: ");
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