using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Model = SAModels;
using Entity = SADL.Entities;
using System.Linq;

namespace SADL
{
    public class CustomerRepo : ICustomerRepo
    {
        private Entity.ieoDemoDBContext _context;
        public CustomerRepo(Entity.ieoDemoDBContext p_context)
        {
            _context = p_context;
        }
        public void AddCustomer(Model.Customer p_customer)
        {
            _context.Customers.Add(new Entity.Customer{
                CustomerId = p_customer.Id,
                CustomerName = p_customer.Name,
                CustomerAddress = p_customer.Address,
                CustomerEmail = p_customer.Email,
                CustomerPhone = p_customer.Phone
            });

            _context.SaveChanges();
        }
        public List<Model.Customer> GetAllCustomers()
        {
            // Method Syntax Way
            return _context.Customers.Select(
                customer =>
                    new Model.Customer()
                    {
                        Id = customer.CustomerId,
                        Name = customer.CustomerName,
                        Address = customer.CustomerAddress,
                        Email = customer.CustomerEmail,
                        Phone = customer.CustomerPhone

                    }
            ).ToList();
        }

        public Model.Customer GetOneCustomer(string p_customerEmail)
        {
            var test =  _context.Customers.Select(
                customer => new Model.Customer()
                    {
                        Id = customer.CustomerId,
                        Name = customer.CustomerName,
                        Address = customer.CustomerAddress,
                        Email = customer.CustomerEmail,
                        Phone = customer.CustomerPhone
                    }
            ).Where(check => check.Email == p_customerEmail);

            return test.SingleOrDefault();

        }
    }
}