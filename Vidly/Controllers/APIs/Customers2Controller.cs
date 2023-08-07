using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.APIs
{
    public class Customers2Controller : ApiController
    {
        private ApplicationDbContext _context;
        public Customers2Controller(){
            _context = new ApplicationDbContext();
        }
        // GET api/customers2 Tar fram alla Customers 
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET api/customers2/5 Fetchar specifik Customer med hjälp av ID
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                Console.Write("costumer not found");
            } else 
            {
                return customer;
            }
        }

        // POST api/customers2
        public Customer AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        // PUT api/customers2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/customers2/5
        public void Delete(int id)
        {
        }
    }
}
