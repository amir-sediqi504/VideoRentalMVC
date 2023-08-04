using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movies/random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "mr & mrs sediqi" };
            return View(movie);
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