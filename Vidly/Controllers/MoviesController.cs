using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;
namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context; // Private field to hold the DbContext

        public MoviesController()
        {
            _context = new ApplicationDbContext(); // Initialize your DbContext
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        // Get: /movies 

        public ActionResult Index()
        {
            var movie = new Movie() { Name = "film 1" };
           
            

            return View(movie); 
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }


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