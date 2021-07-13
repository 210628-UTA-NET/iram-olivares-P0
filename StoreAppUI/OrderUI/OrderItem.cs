using System;
using System.Threading;
using SABL;
using SAModels;

namespace StoreAppUI
{
    public class OrderItem : IMenu
    {
        private IOrderBL _orderBL;
        private ICustomerBL _customerBL;
        private IStoreFrontBL _storeBL;
        public OrderItem(IOrderBL p_orderBL)
        {
            _orderBL = p_orderBL;
        }
        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    return AvailableMenu.StoreMenu;
                case "1":
                    return AvailableMenu.ConfirmOrder;
                case "a" or "A":
                    return AvailableMenu.OrderItem;
                case "b" or "B":
                    return AvailableMenu.OrderItem;
                default:
                    Console.WriteLine("Invalid Input");
                    Thread.Sleep(1000);
                    return AvailableMenu.OrderItem;
            }
        }

        public void CurrentMenu()
        {
            Console.WriteLine("==== Order Menu ====");
            Console.WriteLine("Customer: ");
            Console.WriteLine("Ordering From: ");
            Console.WriteLine("Checkout Items: ");
            Console.WriteLine("Total Price: ");
            Console.WriteLine("[0] Return to Store Menu");
            Console.WriteLine("[1] Proceed to Confirmation (All Fields Below Must be Filled)");
            Console.WriteLine("[A] Add Item to Order");
            Console.WriteLine("[B] Remove Item from Order");
        }
    }
}