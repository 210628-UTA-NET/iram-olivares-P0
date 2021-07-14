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
        public static Customer tempCustomer = new Customer();
        public static Order tempOrder = new Order();
        public static StoreFront tempStore = new StoreFront();
        public static List<LineItem> tempInventory = new List<LineItem>();
        public static List<LineItem> dbInventory = new List<LineItem>();
        private void ReInitialize()
        {
            chosenStore = 0;
            chosenCustomer = "";
            tempCustomer = new Customer();
            tempOrder = new Order();
            tempStore = new StoreFront();
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

            switch (p_menu)
            {
                case AvailableMenu.MainMenu:
                    return new MainMenu();
                case AvailableMenu.StoreMenu:
                    this.ReInitialize();
                    return new StoreMenu();
                case AvailableMenu.AddCustomer:
                    return new AddCustomer(new CustomerBL(new CustomerRepo(new Entity.ieoDemoDBContext(options))));
                case AvailableMenu.ShowAllCustomers:
                    return new ShowAllCustomers(new CustomerBL(new CustomerRepo(new Entity.ieoDemoDBContext(options))));
                case AvailableMenu.SearchForCustomer:
                    return new SearchForCustomer(new CustomerBL(new CustomerRepo(new Entity.ieoDemoDBContext(options))));
                case AvailableMenu.ShowAllStores:
                    return new ShowAllStores(new StoreFrontBL(new StoreFrontRepo(new Entity.ieoDemoDBContext(options))));
                case AvailableMenu.ShowStoreInventory:
                    return new ShowStoreInventory(new StoreFrontBL(new StoreFrontRepo(new Entity.ieoDemoDBContext(options))));
                case AvailableMenu.OrderSetup:
                    return new OrderSetup(new CustomerBL(new CustomerRepo(new Entity.ieoDemoDBContext(options))), 
                                          new StoreFrontBL(new StoreFrontRepo(new Entity.ieoDemoDBContext(options))));
                case AvailableMenu.OrderItem:
                    return new OrderItem(new CustomerBL(new CustomerRepo(new Entity.ieoDemoDBContext(options))), 
                                         new StoreFrontBL(new StoreFrontRepo(new Entity.ieoDemoDBContext(options))), 
                                         new OrderBL(new OrderRepo(new Entity.ieoDemoDBContext(options))));
                case AvailableMenu.ConfirmOrder:
                    return new ConfirmOrder(new StoreFrontBL(new StoreFrontRepo(new Entity.ieoDemoDBContext(options))),
                                            new OrderBL(new OrderRepo(new Entity.ieoDemoDBContext(options))));
                default:
                    return null;
            }
        }
    }
}