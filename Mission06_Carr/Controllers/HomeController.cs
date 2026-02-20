using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Carr.Models;

namespace Mission06_Carr.Controllers;

// All controllers in one file
public class HomeController : Controller
{
    private MovieCollectionContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(MovieCollectionContext movieCollectionContext, ILogger<HomeController> logger)
    {
        _context = movieCollectionContext;
        _logger = logger;
    }

    // GET: Home page
    public IActionResult Index()
    {
        return View();
    }

    // GET: About Joel page
    public IActionResult JoelInfo()
    {
        return View();
    }

    // GET: Display the add movie form
    [HttpGet]
    public IActionResult MoviesList()
    {
        // Pass categories to the view for the dropdown
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();

        return View();
    }

    // POST: Add a new movie to the collection
    [HttpPost]
    public IActionResult MoviesList(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return View("Confirmation", movie);
        }
        else
        {
            // If validation fails, reload categories and return the form with errors
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(movie);
        }
    }

    // GET: Display all movies in the collection
    public IActionResult ViewCollection()
    {
        // Include the Category navigation property for display
        var movies = _context.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Title)
            .ToList();

        return View(movies);
    }

    // GET: Display the edit form for a specific movie
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.Find(id);

        if (movie == null)
        {
            return NotFound();
        }

        // Pass categories to the view for the dropdown
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();

        return View(movie);
    }

    // POST: Update a movie in the collection
    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Update(movie);
            _context.SaveChanges();

            return RedirectToAction("ViewCollection");
        }
        else
        {
            // If validation fails, reload categories and return the form with errors
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(movie);
        }
    }

    // GET: Display the delete confirmation page
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies
            .Include(m => m.Category)
            .FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // POST: Delete a movie from the collection
    [HttpPost]
    public IActionResult DeleteConfirmed(int movieId)
    {
        var movie = _context.Movies.Find(movieId);

        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        return RedirectToAction("ViewCollection");
    }
}