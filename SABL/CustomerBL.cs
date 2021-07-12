using System;
using System.Collections.Generic;
using SADL;
using SAModels;

namespace SABL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepo _customerRepo;

        public CustomerBL(ICustomerRepo p_customerRepo)
        {
            _customerRepo = p_customerRepo;
        }

        public void AddCustomer(Customer p_customer)
        {
            _customerRepo.AddCustomer(p_customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.GetAllCustomers();
        }

        public Customer GetOneCustomer(string p_customerEmail)
        {
            return _customerRepo.GetOneCustomer(p_customerEmail);
        }

        public Order PlaceOrder(Customer p_customer, StoreFront p_store, List<LineItem> p_orderList)
        {
            throw new NotImplementedException();
        }

        public List<Order> ViewCustomerOrderHistory(Customer p_customer)
        {
            throw new NotImplementedException();
        }
    }
}