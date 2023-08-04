using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: /Customers/
        public ActionResult Index()
        {
            // Create a list of customers
            var customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Customer 1" },
            new Customer { Id = 2, Name = "Customer 2" }
        };

            return View(customers);
        }
        // details action method
        public ActionResult Details(int id)
        {
            
            var customer = new Customer { Id = id, Name = "Sample Customer" };

            return View(customer);
        }
    }
}