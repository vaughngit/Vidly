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
        // GET: Customers
        public ActionResult Index()
        {

            // create instance of customer view
            var customers = new List<Customer>
            {
                new Customer {Id  = 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Mary Williams"}
            };


            var customerlist = new MultiCustomer
            {
                Customers = customers
            };

            return View(customerlist);
        }




        // use regular expression to apply constrants (\\d represents a digit, and {2} represents the number of digits.
        [Route("Customers/Details/{cusId:regex(\\d{1}):range(1, 9)}")]
        //The Attribute route does not have to match the proceding method name.
        public ActionResult Details(int cusId)
        {
            

            return View();
        }

    }
}