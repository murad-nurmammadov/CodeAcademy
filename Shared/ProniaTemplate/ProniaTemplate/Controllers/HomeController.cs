using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTemplate.Contexts;
using ProniaTemplate.Models;
using ProniaTemplate.ViewModels;
using System.Diagnostics;

namespace ProniaTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //GenericRepository<Slider> sliderRepo = new GenericRepository<Slider>();
            //var sliders=await sliderRepo.GetAllAsync();
            using var context = new ProniaDbContext();

            var sliders = await context.Sliders.ToListAsync();
            var services = await context.Services.ToListAsync();

            HomeViewModel model = new()
            {
                Sliders = sliders,
                Services = services,
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
}
