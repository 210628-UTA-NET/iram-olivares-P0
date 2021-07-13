using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SABL;
using SADL;
using SADL.Entities;

namespace StoreAppUI
{
    public class MenuFactory : IMenuFactory
    {
        public static int chosenStore;
        public static int chosenCustomer;
        public IMenu GetMenu(AvailableMenu p_menu)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
                
            string connectionString = configuration.GetConnectionString("KeyReference");
            DbContextOptions<ieoDemoDBContext> options = new DbContextOptionsBuilder<ieoDemoDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            switch (p_menu)
            {
                case AvailableMenu.MainMenu:
                    return new MainMenu();
                case AvailableMenu.StoreMenu:
                    return new StoreMenu();
                case AvailableMenu.AddCustomer:
                    return new AddCustomer(new CustomerBL(new CustomerRepo(new ieoDemoDBContext(options))));
                case AvailableMenu.ShowAllCustomers:
                    return new ShowAllCustomers(new CustomerBL(new CustomerRepo(new ieoDemoDBContext(options))));
                case AvailableMenu.SearchForCustomer:
                    return new SearchForCustomer(new CustomerBL(new CustomerRepo(new ieoDemoDBContext(options))));
                case AvailableMenu.ShowAllStores:
                    return new ShowAllStores(new StoreFrontBL(new StoreFrontRepo(new ieoDemoDBContext(options))));
                case AvailableMenu.ShowStoreInventory:
                    return new ShowStoreInventory(chosenStore, new StoreFrontBL(new StoreFrontRepo(new ieoDemoDBContext(options))));
                case AvailableMenu.OrderItem:
                    
                default:
                    return null;
            }
        }
    }
}