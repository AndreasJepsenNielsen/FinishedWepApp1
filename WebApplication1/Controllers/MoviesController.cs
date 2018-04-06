using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context; // giver vores applicationdbcontext navnet _context

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ViewResult Index()
        {
            if(User.IsInRole(RoleName.CanManageMovies))  
            return View("List");
            
            
                return View("ReadOnlyList");
            
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
           
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
               
                Genres = genres
            };

            return View("MovieForm", viewModel); // Koden her tager fat i en ny genre og bruger movieform til at lave en ny film
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            { 
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel); // Koden her tager fat i id og prøver at finde en matchende film, hvis den ikke findes får vi en 404 error, hvis den findes bliver vi smidt ind i Movieform, som både gælder for edit og new movie.
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id); 

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                    
                };

                return View("MovieForm", viewModel);

            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now; // denne kode er hvis filmen ikke findes altså har en Id på 0, også laver den en ny film uden store problemer
                movie.NumberAvailable = movie.NumberInStock;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id); // i dette stykke kode tager vi så fat i at der findes en film, og manuelt setter alle værdierne, der er en hurtigere måde men den måde gør at alle kan ændre i værdierne
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
               
            }

            _context.SaveChanges(); // gemmer værdien/værdierne

            return RedirectToAction("Index", "Movies"); //redirecter til Index action og controlleren movies
        }
    }
}