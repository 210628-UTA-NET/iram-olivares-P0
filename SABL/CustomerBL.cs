using System;
using System.Collections.Generic;
using SADL;
using SAModels;

namespace SABL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepo _customerRepo;

        /// <summary>
        /// Defining dependencies for the class' constructor
        /// Using an interface as a parameter so that interchange is possible
        /// </summary>
        /// <param name="p_customerRepo"></param>
        public CustomerBL(ICustomerRepo p_customerRepo)
        {
            _customerRepo = p_customerRepo;
        }

        public void AddCustomer(Customer p_customer)
        {
            _customerRepo.AddCustomer(p_customer);
        }

        /// <summary>
        /// Get current list of customers
        /// </summary>
        /// <returns> Returns list of customers from the database that is implemented </returns>
        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.GetAllCustomers();
        }

        public Customer GetOneCustomer(string p_customerEmail)
        {
            return null;
        }
    }
}