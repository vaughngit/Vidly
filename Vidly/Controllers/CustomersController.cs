﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using System.Data.Entity;  // needed by Include method in Index action 

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // Create a default constructor to open connection to database: 
        private ApplicationDbContext _context; //this private declares the DbContext class to interface with the database

        public CustomersController()  // default class constructor shortcut key is ctor
        {
            _context = new ApplicationDbContext(); // initialize the DBContent class to connect to database  
        }


        // the ApplicationDbContext object represented by the _context is a disposable object which needs to be 
        // disposed via overriding dispose method of the base controller class : shortcut: override Dispose: 
        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _context.Dispose();
        }


        // GET: Customers
        public ViewResult Index()
        {
            // var customers = GetCustomers();
            // var customers = _context.Customers; // get all customers from the database (executed when view is called/displayed)
            // var customers = _context.Customers.ToList(); // immediately calls the data from the database

            // Lecture 30 eager loading: loads related tables/objects with called/target table
            //add using System.Data.Entity for Include method ;
            // c as in customer goes to membershiptype 
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); 
            return View(customers);
        }




        // use regular expression to apply constrants (\\d represents a digit, and {2} represents the number of digits.
       // [Route("Customers/Details/{Id:regex(\\d{1}):range(1, 9)}")]
        //The Attribute route does not have to match the proceding method name.
        public ActionResult Details(int id)
        {
            //SingleOrDefault: Returns the only element of a sequence, or a default value if the sequence is empty; this method throws an exception if there is more than one element in the sequence.
            //  var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id); // customers data is immediately called 

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer); 
        }


       /* No longer needed since database incorporation via pcakge manager console cmd migration in section 29
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Mary Williams"}
            };
        }

    */
    }
}