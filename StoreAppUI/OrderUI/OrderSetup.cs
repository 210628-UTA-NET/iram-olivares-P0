using System;
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
            Customer checkCustomer = new Customer();
            StoreFront checkStore = new StoreFront();

            switch(input)
            {
                case "0":
                    return AvailableMenu.CustomerPortal;
                case "1":
                    if (MenuFactory.chosenStore == 0 || MenuFactory.chosenCustomer == "")
                    {
                        Console.WriteLine("Please Fill Out All Fields");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.OrderSetup;
                    }
                    MenuFactory.dbInventory = _storeBL.ViewInventory(MenuFactory.tempStore);
                    return AvailableMenu.OrderItem;

                case "a" or "A":
                    Console.Write("Enter Store ID Number: ");
                    input = Console.ReadLine();
                    try
                    {
                        MenuFactory.chosenStore = Int32.Parse(input);
                    }
                    catch(System.Exception)
                    {
                        Console.WriteLine("Please Enter an Existing Store ID");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.OrderSetup;
                    }
                    checkStore = _storeBL.GetOneStore(MenuFactory.chosenStore);
                    if(checkStore == null)
                    {
                        Console.WriteLine("Please Enter an Existing Store ID");
                        MenuFactory.chosenStore = 0;
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.OrderSetup;
                    }
                    MenuFactory.tempStore = checkStore;
                    return AvailableMenu.OrderSetup;

                case "b" or "B":
                    Console.Write("Enter Customer Email: ");
                    input = Console.ReadLine();
                    checkCustomer = _customerBL.GetOneCustomer(input);
                    if (checkCustomer == null)
                    {
                        Console.WriteLine("Please Enter an Existing Customer's Email");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.OrderSetup;
                    }
                    MenuFactory.chosenCustomer = input;
                    MenuFactory.tempCustomer = checkCustomer;
                    return AvailableMenu.OrderSetup;

                default:
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.OrderSetup;
            }
        }

        public void CurrentMenu()
        {
            Console.WriteLine("==== Order Menu ====");
            Console.WriteLine("[0] Return to Customer Portal");
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