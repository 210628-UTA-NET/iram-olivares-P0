using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SABL;
using SADL;
using Entity = SADL.Entities;
using SAModels;
using System.Collections.Generic;

namespace StoreAppUI
{
    public class MenuFactory : IMenuFactory
    {
        public static string checker;
        public static int chosenStore;
        public static string chosenCustomer;
        public static uint amount;
        public static Customer tempCustomer = new Customer();
        public static Order tempOrder = new Order();
        public static StoreFront tempStore = new StoreFront();
        public static LineItem tempItem = new LineItem();
        public static List<LineItem> tempInventory = new List<LineItem>();
        public static List<LineItem> dbInventory = new List<LineItem>();
        private void ReInitialize()
        {
            chosenStore = 0;
            chosenCustomer = "";
            amount = 0;
            tempCustomer = new Customer();
            tempOrder = new Order();
            tempStore = new StoreFront();
            tempItem = new LineItem();
            tempInventory = new List<LineItem>();
            dbInventory = new List<LineItem>();
        }
        public IMenu GetMenu(AvailableMenu p_menu)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
                
            string connectionString = configuration.GetConnectionString("KeyReference");
            DbContextOptions<Entity.ieoDemoDBContext> options = new DbContextOptionsBuilder<Entity.ieoDemoDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            ICustomerBL customerBL = new CustomerBL(new CustomerRepo(new Entity.ieoDemoDBContext(options)));
            IStoreFrontBL storeBL = new StoreFrontBL(new StoreFrontRepo(new Entity.ieoDemoDBContext(options)));
            IOrderBL orderBL = new OrderBL(new OrderRepo(new Entity.ieoDemoDBContext(options)));

            switch (p_menu)
            {
                case AvailableMenu.MainMenu:
                    return new MainMenu();
                case AvailableMenu.StoreMenu:
                    this.ReInitialize();
                    return new StoreMenu();
                case AvailableMenu.CustomerPortal:
                    this.ReInitialize();
                    return new CustomerPortal();
                case AvailableMenu.AddCustomer:
                    return new AddCustomer(customerBL);
                case AvailableMenu.ShowAllCustomers:
                    return new ShowAllCustomers(customerBL);
                case AvailableMenu.SearchForCustomer:
                    return new SearchForCustomer(customerBL);
                case AvailableMenu.ShowAllStores:
                    return new ShowAllStores(storeBL);
                case AvailableMenu.ShowStoreInventory:
                    return new ShowStoreInventory(storeBL);
                case AvailableMenu.OrderSetup:
                    return new OrderSetup(customerBL, storeBL);
                case AvailableMenu.OrderItem:
                    return new OrderItem(customerBL, storeBL, orderBL);
                case AvailableMenu.ConfirmOrder:
                    return new ConfirmOrder(storeBL, orderBL);
                case AvailableMenu.ReplenishInventory:
                    return new ReplenishInventory(storeBL);
                case AvailableMenu.ShowStoreOrders:
                    return new ShowStoreOrders(storeBL, orderBL);
                case AvailableMenu.ShowCustomerOrders:
                    return new ShowCustomerOrders(customerBL, orderBL);
                default:
                    return null;
            }
        }
    }
}