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
    }
}