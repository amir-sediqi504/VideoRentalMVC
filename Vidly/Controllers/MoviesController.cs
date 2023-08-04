using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movies/random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "mr & mrs sediqi" };
            

            var customers = new List<Customer>
            {
                new Customer{Name="Gäst1"},
                new Customer{Name="C2"}
            };

            RandomMovieViewModel randomMovieViewModel = new RandomMovieViewModel 
            { 
                Movie = movie,
                Customers = customers
            };

            return View(randomMovieViewModel);

        }
        // Get: /movies/param
        public ActionResult Param(int id)
        {
            return Content  ("id = " + id);
        }
        [Route("movies/released/{year}/{month: regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/ " + month);
        }
	}
}