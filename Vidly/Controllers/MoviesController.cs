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
        // GET: /Movies/
        public ActionResult Index()
        {
            var movie = new Movie() { Name = "mr & mrs sediqi" };
            return View();
        }
	}
}