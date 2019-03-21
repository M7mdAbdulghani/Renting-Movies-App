using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        //Movies/Random
        public ActionResult Random()
        {
            //var movie = new Movie()
            //{
            //    Id = 1,
            //    Name = "Harry Potter"
            //};

            //var customers = new List<Customer>()
            //{
            //    new Customer(){Name = "Customer 1"},
            //    new Customer(){Name = "Customer 2"}
            //};

            ////var customers = new List<Customer>();
            //var viewModel = new RandomMovieViewModel()
            //{
            //    Movie = movie,
            //    Customers = customers
            //};

            //var movies = new List<Movie>()
            //{
            //    new Movie(){Id = 1, Name = "Harry Potter"},
            //    new Movie(){Id = 2, Name = "Shrek"}
            //};
            ////ViewData["Movie"] = movie;
            ////ViewBag.Movie = movie;

            //return View(movies);
            var movie = new Movie()
            {
                Id = 1,
                Name = "Harry Potter"
            };
            var customers = new List<Customer>()
            {
                new Customer() { Name = "Customer 1" },
                new Customer() { Name = "Customer 2" },
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            //return RedirectToAction("Index", "Home", new { page = 2, sortBy = "name"});
            //http://localhost:56112/?page=2&sortBy=name
            //return new EmptyResult();
            //return Content("Hello World");
            //return HttpNotFound();
            
            
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        
        //movies    
        //public ActionResult Index(int ? page, string sortBy)
        //{
        //    if (!page.HasValue)
        //        page = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("page={0}&sortBy={1}", page, sortBy));
        //}

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            var movie = new List<Movie>()
            {
                new Movie(){ Id = 1, Name = "Harry Potter"},
                new Movie(){ Id = 2, Name = "Shooter"}
            };

            return View(movie);
        }
    }
}