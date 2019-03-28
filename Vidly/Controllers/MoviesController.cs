using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        Models.Database db = new Models.Database();


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
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
            var movie = db.Movie.Include(M => M.Genre).ToList();
           

            return View(movie);
        }

        public ActionResult New()
        {
            var genres = db.Genres.ToList();

            var viewModel = new NewMovieViewModel()
            {
                Genres = genres
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = db.Movie.SingleOrDefault(m => m.Id == id);

            var viewModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = db.Genres.ToList()
            };

            return View("New", viewModel);
        }

        public ActionResult Create(Movie movie)
        {
            var movieInDB = db.Movie.SingleOrDefault(m => m.Id == movie.Id);

            if (movieInDB == null)
                db.Movie.Add(movie);
            else
            {
                movieInDB.Name = movie.Name;
                movieInDB.NumberInStock = movie.NumberInStock;
                movieInDB.ReleasedDate = movie.ReleasedDate;
                movieInDB.GenreId = movie.GenreId;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int id)
        {
            var movie = db.Movie.Include(M => M.Genre).SingleOrDefault(movieId => movieId.Id == id);
            if (movie == null)
                return HttpNotFound();
            else
            {
                return View(movie);
            }
        }
    }
}