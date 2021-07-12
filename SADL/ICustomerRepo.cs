using System;
using System.Collections.Generic;
using SAModels;

namespace SADL
{

    /// <summary>
    /// Responsible for accessing the Customer Database
    /// </summary>
    public interface ICustomerRepo
    {
        /// <summary>
        /// AddCustomer takes in a previously created Customer Object and adds it to a database (or collection)
        /// Does not return anything since a Customer is only being added
        /// </summary>
        /// <param name="p_customer"> Customer object as an input </param>
        void AddCustomer(Customer p_customer);

        /// <summary>
        /// GetAllCustomers will retrieve the list of customers from the database
        /// Deserializes the included JSON file
        /// </summary>
        /// <returns> Returns the list of customers from the database </returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// GetOneCustomer will search the database for a Customer
        /// </summary>
        /// <param name="p_customerEmail"> Takes an email string that will compare to all emails in the database </param>
        /// <returns> Will return a Customer if found, null otherwise </returns>
        Customer GetOneCustomer(string p_customerEmail);

        /// <summary>
        /// An existing customer chooses a store and a list of items to order
        /// </summary>
        /// <param name="p_customer"> Customer that wishes to place an order </param>
        /// <param name="p_store"> Which store the order will take place </param>
        /// <param name="p_orderList"> List of items the customer wishes to order </param>
        /// <returns> Returns an order to be added to the database </returns>
        Order PlaceOrder(Customer p_customer, StoreFront p_store, List<LineItem> p_orderList);

        /// <summary>
        /// Allows the user to view a customer's order history
        /// </summary>
        /// <param name="p_customer"> Takes in a customer as a parameter </param>
        /// <returns> Will return a list of a customer's orders </returns>
        List<Order> ViewCustomerOrderHistory(Customer p_customer);
    }
}