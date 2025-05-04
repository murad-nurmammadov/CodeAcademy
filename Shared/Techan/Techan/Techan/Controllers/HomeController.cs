using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;
using Techan.Models;
using Techan.ViewModels;
using Techan.ViewModels.Slider;

namespace Techan.Controllers;

public class HomeController : Controller
{
    private readonly TechanDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, TechanDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {        
        List<Slider> sliders = await _context.Sliders.ToListAsync();
        
        List<SliderGetVM> sliderVMs = sliders.Select(s => new SliderGetVM
        {
            SliderId = s.Id,
            Subtitle =s.Subtitle,
            Title = s.Title,
            Highlight = s.Highlight,
            Description = s.Description,
            ButtonText = s.ButtonText,
            ButtonLink = s.ButtonLink,
            ImageFileName = s.ImageFileName,
        }).ToList();

        HomeViewModel model = new()
        {
            Sliders = sliderVMs,
        };

        return View(model);
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
