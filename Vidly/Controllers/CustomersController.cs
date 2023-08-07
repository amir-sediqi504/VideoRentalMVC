using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;


namespace Vidly.Controllers
{
    //    public class CustomersController : Controller
    //    {
    //        // GET: /Customers/
    //        public ActionResult Index()
    //        {
    //            // Create a list of customers
    //            var customers = new List<Customer>
    //        {
    //            new Customer { Id = 1, Name = "Customer 1" },
    //            new Customer { Id = 2, Name = "Customer 2" }
    //        };

    //            return View(customers);
    //        }
    //        // details action method
    //        public ActionResult Details(int id)
    //        {

    //            var customer = new Customer { Id = id, Name = "Sample Customer" };

    //            return View(customer);
    //        }
    //    }
    //}

    public class CustomersController : Controller
    {

        private readonly ApplicationDbContext _context; // Private field to hold the DbContext

        public CustomersController()
        {
            _context = new ApplicationDbContext(); // Initialize your DbContext
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       

        // :-- CREATE

        public ActionResult Create(Customer customer)
        {


            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType ).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel 
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
        
    }
}

//

