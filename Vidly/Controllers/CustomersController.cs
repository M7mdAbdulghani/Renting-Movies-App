using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        Models.Database db = new Models.Database();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        //public List<Customer> GetCustomers()
        //{
        //    var customers = new List<Customer>()
        //    {
        //        new Customer() { Id = 1, Name = "Mohamed Abdulghani" },
        //        new Customer() { Id = 2, Name = "Mohannad Noman" }
        //    };
        //    return customers;
        //}
        // GET: Customers
        public ActionResult New()
        {
            var membershipTypes = db.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = db.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }
            var customerInDB = db.Customer.SingleOrDefault(customerID => customerID.Id == customer.Id);

            if(customerInDB == null)
            {
                db.Customer.Add(customer);
            }
            else
            {
                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = db.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = db.MembershipTypes.ToList()
            };

            return View("New", viewModel);
        }

        public ActionResult Index()
        {
            var customers = db.Customer.Include(Customer => Customer.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            //---------------------- Option 1 ---------------------------------
            //var custom = new Customer();
            //foreach (var customer in GetCustomers())
            //{
            //    if (customer.Id == id)
            //    {
            //        custom.Id = customer.Id;
            //        custom.Name = customer.Name;
            //    }
            //}
            
            //---------------------- option 2 ---------------------------------
            //var customer = GetCustomers().Where(customerId => customerId.Id == id).SingleOrDefault();
            
            //---------------------- Option 3 ---------------------------------
            var customer = db.Customer.Include(Customer => Customer.MembershipType).SingleOrDefault(customerId => customerId.Id == id);
            if (customer == null)
                return HttpNotFound();
            else
                return View(customer);
        }
    }
}