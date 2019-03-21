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
        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer() { Id = 1, Name = "Mohamed Abdulghani" },
                new Customer() { Id = 2, Name = "Mohannad Noman" }
            };
            return customers;
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
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
            var customer = GetCustomers().SingleOrDefault(customerId => customerId.Id == id);
            if (customer == null)
                return HttpNotFound();
            else
                return View(customer);
        }
    }
}