using System;

namespace StoreAppUI
{
    public class MainMenu : IMenu
    {
        public void CurrentMenu()
        {
            Console.WriteLine("==== Main Menu ====");
            Console.WriteLine("Select Option and Press Enter");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("[1] Store Menu");
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
                    return AvailableMenu.StoreMenu;
                default:
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.MainMenu;
            }
        }
    }
}