using SAModels;
using SABL;
using System;

namespace StoreAppUI
{
    public class ReplenishInventory : IMenu
    {
        private IStoreFrontBL _storeBL;
        public ReplenishInventory(IStoreFrontBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();
            StoreFront checkStore = new StoreFront();
            LineItem checkItem = new LineItem();

            switch(input)
            {
                case "0":
                    return AvailableMenu.StoreMenu;

                case "1":
                    if (MenuFactory.tempItem == null)
                    {
                        Console.WriteLine("Please Fill The Fields Below");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.ReplenishInventory;
                    }

                    MenuFactory.dbInventory = _storeBL.ReplenishInventory(MenuFactory.tempStore, MenuFactory.tempItem, (int)MenuFactory.amount);
                    Console.WriteLine(MenuFactory.amount + " of " + MenuFactory.tempItem.Item + " Has Been Added To " + MenuFactory.tempStore.Name + "!");
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.StoreMenu;

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
                        return AvailableMenu.ReplenishInventory;
                    }
                    checkStore = _storeBL.GetOneStore(MenuFactory.chosenStore);
                    if(checkStore == null)
                    {
                        Console.WriteLine("Please Enter an Existing Store ID");
                        MenuFactory.chosenStore = 0;
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.ReplenishInventory;
                    }
                    MenuFactory.tempStore = checkStore;
                    return AvailableMenu.ReplenishInventory;

                case "b" or "B":
                    if (MenuFactory.chosenStore == 0)
                    {
                        Console.WriteLine("Please Enter a Store ID First");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.ReplenishInventory;
                    }

                    Console.Write("Enter Item to Replenish: ");
                    input = Console.ReadLine();
                    checkItem = _storeBL.GetOneItem(input, MenuFactory.tempStore);

                    if (checkItem == null)
                    {
                        Console.WriteLine("No Such Item In The Store!");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.ReplenishInventory;
                    }

                    Console.Write("Enter Amount to Replenish: ");
                    input = Console.ReadLine();

                    try
                    {
                        MenuFactory.amount = UInt32.Parse(input);
                    }
                    catch(System.Exception)
                    {
                        Console.WriteLine("Please Enter a Positive Integer");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.ReplenishInventory;
                    }
                    if (MenuFactory.amount == 0)
                    {
                        Console.WriteLine("Please Enter a Positive Integer");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.ReplenishInventory;
                    }
                    
                    MenuFactory.tempItem = checkItem;
                    return AvailableMenu.ReplenishInventory;

                default:
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.ReplenishInventory;
            }
        }

        public void CurrentMenu()
        {
            Console.WriteLine(@"
  ___          _          _    _      ___                 _                
 | _ \___ _ __| |___ _ _ (_)__| |_   |_ _|_ ___ _____ _ _| |_ ___ _ _ _  _ 
 |   / -_) '_ \ / -_) ' \| (_-< ' \   | || ' \ V / -_) ' \  _/ _ \ '_| || |
 |_|_\___| .__/_\___|_||_|_/__/_||_| |___|_||_\_/\___|_||_\__\___/_|  \_, |
         |_|                                                          |__/ 
");

            Console.WriteLine("[0] Return to Store Menu");
            Console.WriteLine("[1] Replenish Chosen Item (Fields Must Be Filled Below)");
            if (MenuFactory.chosenStore == 0)
            {
                Console.WriteLine("[A] Store ID Number: ");
            }
            else
            {
                Console.WriteLine("[A] Store ID Number: " + MenuFactory.chosenStore);
            }
            if (MenuFactory.amount == 0)
            {
                Console.WriteLine("[B] Item to Replenish: ");
            }
            else
            {
                Console.WriteLine("[B] Item to Replenish: " + MenuFactory.amount + MenuFactory.tempItem.Item);
            }
            Console.Write("Enter Input: ");
        }
    }
}