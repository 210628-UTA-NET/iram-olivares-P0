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
                Id = p_customer.Id,
                Name = p_customer.Name,
                Address = p_customer.Address,
                Email = p_customer.Email,
                Phone = p_customer.Phone
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
                        Id = customer.Id,
                        Name = customer.Name,
                        Address = customer.Address,
                        Email = customer.Email,
                        Phone = customer.Phone

                    }
            ).ToList();
        }
    }
}