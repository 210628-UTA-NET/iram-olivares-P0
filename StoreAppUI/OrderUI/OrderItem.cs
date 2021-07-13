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
        public OrderItem(IOrderBL p_orderBL)
        {
            _orderBL = p_orderBL;
        }
        public AvailableMenu ChooseMenu()
        {
            string input = Console.ReadLine();
            





            return AvailableMenu.ExitApp;
        }

        public void CurrentMenu()
        {
            Console.WriteLine("[0] Return to Store Menu");
            Console.Write("Insert Customer Email of Who Would Like to Order: ");
        }
    }
}