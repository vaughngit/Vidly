using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // apply attribute routing method
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12}")]  // attribute routing allows you to apply multiple constraint types in addition to regex
                                                                             // other constraints are min, max, minlength, int, float, guid, etc for more google 'ASP.NET MVC attribute route constraints'
        
        
        
        
        // GET: Movies/Random
        //public ActionResult Random() // Parent class
        //public ViewResult Random() // subclass of ActionResult
        public ActionResult Random()
        {
            // create instance of the movie model
            var movie = new Movie() {Name = "Shrek!"};

            return View(movie);  // returns move object
            // return Content("Hello World!");
           //  return HttpNotFound(); // returns 404 page not found page
           //return new EmptyResult();    
           // return RedirectToAction("Index", "Home", new {page =1, sortby = "name"});
        }


        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        /*

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // this action will be called when we navigate to movies:
        public ActionResult Index(int? pageIndex, string sortBy) // add ? after parm type to make it nullable thereby making it an optional parameter. the softBy parm is a string type which is a reference type that is nullable by default 
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        */
    }
}