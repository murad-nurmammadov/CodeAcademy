using Microsoft.AspNetCore.Mvc;
using ProniaTemplate.Models;
using ProniaTemplate.Repositories.Implementations;

namespace ProniaTemplate.Controllers
{
    public class BlogController : Controller
    {
        public async Task<IActionResult> Index()
        {
            GenericRepository<Blog> blogRepo = new();
            List<Blog> blogs = await blogRepo.GetAllAsync();
            return View(blogs);
        }
    }
}
