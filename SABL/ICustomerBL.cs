using System;
using System.Collections.Generic;
using SAModels;

namespace SABL
{
    /// <summary>
    /// Any operation beyond accessing the Customer database will be handled here, otherwise it is handled in the DL
    /// Implemented as an interface to interchange data storage methods without compromising large amounts of code
    /// </summary>
    public interface ICustomerBL
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
    }
}
