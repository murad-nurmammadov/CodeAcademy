using Microsoft.AspNetCore.Mvc;
using ProniaTemplate.Models;
using ProniaTemplate.Repositories.Implementations;
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
            GenericRepository<Slider> sliderRepo = new GenericRepository<Slider>();
            var sliders=await sliderRepo.GetAllAsync();
            return View(sliders);
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
