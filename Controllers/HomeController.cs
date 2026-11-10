using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DreamGarage.Models;
using DreamGarage.Data;

namespace DreamGarage.Controllers;

public class HomeController : Controller
{
    private readonly CarContext _context;

    public HomeController(CarContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var featured = _context.Cars.OrderByDescending(c => c.Horsepower).FirstOrDefault();
        return View(featured);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
