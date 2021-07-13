using System;
using System.Threading;
using SABL;
using SAModels;

namespace StoreAppUI
{
    public class OrderSetup : IMenu
    {
        private ICustomerBL _customerBL;
        private IStoreFrontBL _storeBL;
        public OrderSetup(ICustomerBL p_customerBL, IStoreFrontBL p_storeBL)
        {
            _customerBL = p_customerBL;
            _storeBL = p_storeBL;
        }
        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();
            switch(input)
            {
                case "0":
                    MenuFactory.ResetParams();
                    return AvailableMenu.StoreMenu;
                case "1":
                    return AvailableMenu.OrderItem;
                case "a" or "A":
                    Console.Write("Enter Store ID Number: ");
                    MenuFactory.checker = Console.ReadLine();
                    MenuFactory.chosenStore = Int32.Parse(MenuFactory.checker);
                    return AvailableMenu.OrderSetup;
                case "b" or "B":
                    Console.Write("Enter Customer Email: ");
                    MenuFactory.checker = Console.ReadLine();
                    MenuFactory.chosenCustomer = MenuFactory.checker;
                    return AvailableMenu.OrderSetup;
                default:
                    Console.WriteLine("Invalid Input");
                    Thread.Sleep(1000);
                    return AvailableMenu.OrderSetup;
            }
        }

        public void CurrentMenu()
        {
            Console.WriteLine("==== Order Menu ====");
            Console.WriteLine("[0] Return to Store Menu");
            Console.WriteLine("[1] Proceed to Order Menu (Fields below must be filled)");
            if (MenuFactory.chosenStore == 0)
            {
                Console.WriteLine("[A] Store ID Number: ");
            }
            else
            {
                Console.WriteLine("[A] Store ID Number: " + MenuFactory.chosenStore);
            }
            Console.WriteLine("[B] Customer Email: " + MenuFactory.chosenCustomer);
            Console.Write("Select Option: ");
        }
    }
}