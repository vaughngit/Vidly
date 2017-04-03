using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel   // A ViewModel is a model specifically built for a view. It includes any data and rules specific to that view 
    {
        public Movie Movie { get; set; }

        public List<Customer> Customers { get; set;} 
    }
}