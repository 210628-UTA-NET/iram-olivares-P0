using System;
using System.Collections.Generic;
using Entity = SADL.Entities;
using System.Linq;
using SAModels;

namespace SADL
{
    public class CustomerRepo : ICustomerRepo
    {
        private Entity.ieoDemoDBContext _context;
        public CustomerRepo(Entity.ieoDemoDBContext p_context)
        {
            _context = p_context;
        }
        public Customer AddCustomer(Customer p_customer)
        {
            var newCustomer = new Entity.Customer{
                CustomerId = p_customer.Id,
                CustomerName = p_customer.Name,
                CustomerAddress = p_customer.Address,
                CustomerEmail = p_customer.Email,
                CustomerPhone = p_customer.Phone
            };

            _context.Customers.Add(newCustomer);

            _context.SaveChanges();

            return p_customer;
        }
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                customer =>
                    new Customer()
                    {
                        Id = customer.CustomerId,
                        Name = customer.CustomerName,
                        Address = customer.CustomerAddress,
                        Email = customer.CustomerEmail,
                        Phone = customer.CustomerPhone

                    }
            ).ToList();
        }

        public Customer GetOneCustomer(string p_customerEmail)
        {
            return  _context.Customers.Select(
                customer => new Customer()
                    {
                        Id = customer.CustomerId,
                        Name = customer.CustomerName,
                        Address = customer.CustomerAddress,
                        Email = customer.CustomerEmail,
                        Phone = customer.CustomerPhone
                    }
            ).Where(check => check.Email == p_customerEmail).SingleOrDefault();
        }
    }
}