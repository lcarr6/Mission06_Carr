using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Carr.Models;

namespace Mission06_Carr.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

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
        return View("Confirmation", movie);
    }
}