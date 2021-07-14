using System;
using SABL;
using SAModels;

namespace StoreAppUI
{
    public class OrderItem : IMenu
    {
        private IOrderBL _orderBL;
        private ICustomerBL _customerBL;
        private IStoreFrontBL _storeBL;
        private uint amount;
        public OrderItem(ICustomerBL p_customerBL, IStoreFrontBL p_storeBL, IOrderBL p_orderBL)
        {
            _customerBL = p_customerBL;
            _storeBL = p_storeBL;
            _orderBL = p_orderBL;
        }
        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();
            amount = 0;
            LineItem item = new LineItem();
            switch (input)
            {
                case "0":
                    return AvailableMenu.CustomerPortal;

                case "1":
                    if (MenuFactory.tempInventory.Count == 0)
                    {
                        Console.WriteLine("Please Add At Least One Item To Your Cart");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.OrderItem;
                    }
                    return AvailableMenu.ConfirmOrder;

                case "a" or "A":
                    Console.Write("Item to Add: ");
                    MenuFactory.checker = Console.ReadLine();

                    // Check if it exists in the database
                    item = _storeBL.GetOneItem(MenuFactory.checker, MenuFactory.tempStore);
                    if (item == null)
                    {
                        Console.WriteLine("No Such Item In The Store!");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.OrderItem;
                    }

                    // Check if the requested item is in the Shopping Cart, if so, then state it is and return
                    foreach(LineItem inventoryItem in MenuFactory.tempInventory)
                    {
                        if (inventoryItem.Item.Equals(item.Item))
                        {
                            Console.WriteLine("Item Already In The Cart!");
                            Console.Write("Enter Any Key to Return: ");
                            Console.ReadLine();
                            return AvailableMenu.OrderItem;
                        }
                    }

                    Console.Write("How Many Would You Like To Order?: ");
                    input = Console.ReadLine();

                    // Check if the input is a positive integer
                    try
                    {
                        amount = UInt32.Parse(input);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Please Insert a Positive Integer");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.OrderItem;
                    }
                    if (amount == 0)
                    {
                        Console.WriteLine("Please Insert a Positive Integer");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.OrderItem;
                    }

                    // Check if there are enough requested items
                    foreach (LineItem inventoryItem in MenuFactory.dbInventory)
                    {
                        if (inventoryItem.Item.Equals(item.Item))
                        {
                            if ((inventoryItem.Quantity - amount) < 0)
                            {
                                Console.WriteLine("Not Enough Items!");
                                Console.Write("Enter Any Key to Return: ");
                                Console.ReadLine();
                                return AvailableMenu.OrderItem;
                            }
                            else
                            {
                                inventoryItem.Quantity -= (int)amount;
                                item.Quantity = (int)amount;
                            }
                        }
                    }

                    // If item and amount checks out, then add to shopping cart inventory and adjust the temporary database values
                    MenuFactory.tempInventory.Add(item);
                    MenuFactory.tempOrder.Price += _storeBL.GetItemPrice(item) * amount;

                    Console.WriteLine(amount + " " + item.Item + " Successfully Added!");
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.OrderItem;

                case "b" or "B":
                    Console.Write("Item to Remove: ");
                    input = Console.ReadLine();
                    item = _storeBL.GetOneItem(input, MenuFactory.tempStore);

                    // Check if the item exists in the database, report wrong input if not
                    try
                    {
                        item.Quantity = 0;
                    }
                    catch(System.Exception)
                    {
                        Console.WriteLine("No Such Item In The Cart!");
                        Console.Write("Enter Any Key to Return: ");
                        Console.ReadLine();
                        return AvailableMenu.OrderItem;
                    }

                    // Check if the requested item is in the Shopping Cart, if so, then remove it and return
                    // Will also readjust the temporary database values
                    foreach(LineItem inventoryItem in MenuFactory.tempInventory)
                    {
                        if (inventoryItem.Item.Equals(item.Item))
                        {
                            foreach(LineItem dbItem in MenuFactory.dbInventory)
                            {
                                if (inventoryItem.Item.Equals(dbItem.Item))
                                {
                                    dbItem.Quantity += inventoryItem.Quantity;
                                }
                            }
                            MenuFactory.tempOrder.Price -= inventoryItem.Quantity * _storeBL.GetItemPrice(item);
                            MenuFactory.tempInventory.Remove(inventoryItem);
                            Console.WriteLine(item.Item + " Successfully Removed!");
                            Console.Write("Enter Any Key to Return: ");
                            Console.ReadLine();
                            return AvailableMenu.OrderItem;
                        }
                    }

                    // Otherwise the item is not in the cart
                    Console.WriteLine("No Such Item In The Cart!");
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.OrderItem;

                default:
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Any Key to Return: ");
                    Console.ReadLine();
                    return AvailableMenu.OrderItem;
            }
        }

        public void CurrentMenu()
        {
            Console.WriteLine("==== Order Menu ====");
            Console.WriteLine("Customer: " + MenuFactory.tempCustomer.Name);
            Console.WriteLine("Ordering From: " + MenuFactory.tempStore.Name);
            Console.WriteLine("Checkout Items: ");
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
            Console.WriteLine("Total Price: $" + MenuFactory.tempOrder.Price);
            Console.WriteLine("[0] Return to Customer Portal Without Saving");
            Console.WriteLine("[1] Proceed to Confirmation (Requires a minimum of one item in the cart)");
            Console.WriteLine("[A] Add Item to Order");
            Console.WriteLine("[B] Remove Item from Order");
            Console.Write("Select Option: ");
        }
    }
}