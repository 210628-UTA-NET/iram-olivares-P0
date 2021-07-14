using System;

namespace StoreAppUI
{
    public class MainMenu : IMenu
    {
        public void CurrentMenu()
        {
            Console.WriteLine("==== Main Menu ====");
            Console.WriteLine("Select Option and Press Enter");
            Console.WriteLine("[0] Exit Application");
            Console.WriteLine("[1] Customer Portal");
            Console.Write("Enter Input: ");
        }

        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    return AvailableMenu.ExitApp;
                case "1":
                    return AvailableMenu.CustomerPortal;
                case "password: revature is cool":
                    return AvailableMenu.StoreMenu;
                default:
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.MainMenu;
            }
        }
    }
}