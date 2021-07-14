using SABL;
using SAModels;
using System;
using System.Threading;

namespace StoreAppUI
{
    public class ConfirmOrder : IMenu
    {
        private IOrderBL _orderBL;
        private IStoreFrontBL _storeBL;
        public ConfirmOrder(IStoreFrontBL p_storeBL, IOrderBL p_orderBL)
        {
            _storeBL = p_storeBL;
            _orderBL = p_orderBL;
        }
        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();
            
            switch(input)
            {
                case "0":
                    return AvailableMenu.StoreMenu;

                case "1":
                    return AvailableMenu.OrderItem;

                case "2":
                    // Formally place an order and record in the database
                    MenuFactory.tempOrder = _orderBL.PlaceOrder(MenuFactory.tempCustomer, MenuFactory.tempStore, MenuFactory.tempOrder);

                    // Update the database for each item that was purchased
                    foreach(LineItem item in MenuFactory.dbInventory)
                    {   
                        MenuFactory.tempInventory = _storeBL.ReplenishInventory(MenuFactory.tempStore, item, 0);
                    }
                    Console.WriteLine("Order Placed!");
                    Thread.Sleep(1000);
                    return AvailableMenu.StoreMenu;
                    
                default:
                    Console.WriteLine("Invalid Input");
                    Thread.Sleep(1000);
                    return AvailableMenu.ConfirmOrder;
            }
        }

        public void CurrentMenu()
        {
            Console.WriteLine("==== Order Confirmation ====");
            double price;
            foreach(LineItem item in MenuFactory.tempInventory)
            {
                Console.WriteLine("==================");
                Console.WriteLine(item);
                price = _storeBL.GetItemPrice(item);
                Console.WriteLine("$ " + price + " ea.");
                Console.WriteLine("$ " + price*item.Quantity + " Total");
                Console.WriteLine("==================");
            }
            Console.WriteLine("Customer: " + MenuFactory.tempCustomer.Name);
            Console.WriteLine("Ordering From: " + MenuFactory.tempStore.Name);
            Console.WriteLine("Total Price: $" + MenuFactory.tempOrder.Price);
            Console.WriteLine("[0] Remove Order and Return to Store Menu");
            Console.WriteLine("[1] Make Adjustments to Order");
            Console.WriteLine("[2] Place Order");
            Console.Write("Enter Input: ");
        }
    }
}