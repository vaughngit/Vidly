using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {


        // Action Parameters: Lesson 11
        // this action will be called when we navigate to movies index page:
        public ActionResult Index(int? pageIndex, string sortBy)
            // add ? after parm type to make it nullable thereby making it an optional parameter. the softBy parm is a string type which is a reference type that is nullable by default 
        {
            if (!pageIndex.HasValue)
                pageIndex = 1; // if pageIndex doesnt have a value initialize it to 1

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name"; // if string is null or whitespace, initialize it to Name 

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy)); // space the 
        }


        // url for this ActionResult is localhost:port/movies/edit?id=#
        public ActionResult Edit(int? id)
        {
            return Content("id=" + id);
        }





        // GET: Movies/Random
        public ActionResult Random() // This function passes data to the view that calls it 
        {
            // create instance of the movie model
            var movie = new Movie() {Name = "Shrek!"};
            //create an instance of the movie model and assign a value to the name property of this instances 

            // create instance of customer view
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            /*
             Other Action Result Types: 
                  return Content("Hello World!");                                                 // ContentResult
                  return HttpNotFound();                                                         // HttpNotFoundResult returns 404 page not found page
                  return new EmptyResult();                                                     // EmptyResult requires a new declaration since it doesnt have a helper method like the other ActionTypes 
                  return RedirectToAction("Index", "Home", new {page =1, sortby = "name"});    //RedirectToReouteResult - see below
                                /*
                                return RedirectToAction(NameOfAction, Controller);
                                return RedirectToAction(NameOfAction, Controller, new {page = 1, sortby = "name"});  use anonamous object to pass aruguments to a page :
                                page url appears as: http://localhost:port#/?page=1&sortby=name
                                */

            //  return View(movie);                                                          //ViewResult returns move object

            return View(viewModel); // instead of sending the movie as in the line above, we send the viewModel
        }





        // Attribute routing Lesson: 13
        /* attribute routing allows you to apply multiple constraint types in addition to regex other constraints are min, max, minlength, int, float, guid, etc 
         * for more google 'ASP.NET MVC attribute route constraints'                                         
        * Attribute routing is enabled in the RouteConfig.cs file within the App_Start folder, syntax is: routes.MapMvcAttributeRoutes();
        */

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        // use regular expression to apply constrants (\\d represents a digit, and {2} represents the number of digits.
        public ActionResult ByReleaseDate(int year, int month)
            //The Attribute route does not have to match the proceding method name. 
        {
            return Content(year + "/" + month);
        }



    }
}