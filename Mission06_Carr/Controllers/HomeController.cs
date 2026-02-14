using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Carr.Models;

namespace Mission06_Carr.Controllers;

public class HomeController : Controller
{
    private MovieCollectionContext _context;
    public HomeController(MovieCollectionContext movieCollectionContext, ILogger<HomeController> logger)
    {
        _context = movieCollectionContext;
        _logger = logger;
    }
    private readonly ILogger<HomeController> _logger;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult JoelInfo()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult MoviesList()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult MoviesList(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        
        return View("Confirmation", movie);
    }
}