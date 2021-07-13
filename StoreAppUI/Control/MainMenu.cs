using System;
using System.Threading;

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
                    Console.WriteLine("Invalid Input");
                    Thread.Sleep(1000);
                    return AvailableMenu.MainMenu;
            }
        }
    }
}