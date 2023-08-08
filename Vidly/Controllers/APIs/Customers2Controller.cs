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
                throw new HttpResponseException(HttpStatusCode.NotFound);
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
        [HttpPost]
        public void UpdateCustomer(int id, Customer customer)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
        }

        // DELETE api/customers2/5
        [HttpDelete]
        public void Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            _context.Customers.Remove(customer);
        }
    }
}
