using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // attribute routing introduced in MVC 5 and replaces the frigle routes.MapRoute() convention commented out below - see 13 Atribute Routing
            // Atrtibute routing allow you to apply several contraints to routing conditions as seen in route specified in Line 14 of the MoviesController.cs 
             routes.MapMvcAttributeRoutes();  // enable attribute routing for mvc 5 and above 

            /*
            // Convention routing 
            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new {Controller = "Movies", action = "ByReleaseDate"}, // anonymous objective for default route  
              //new { year = @"\d{4}", month = @"\d{2}"}  // use regular expression to apply constrants (\d represents a digit, {4} and {2} represents the number of digits. Use the @ sign to escape the regular backslash escape char
                new { year = @"2015 | 2016", month = @"\d{2}" } // regular expression to constrain the query to two specific years
                );

            */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
