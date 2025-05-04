using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;
using Techan.Models;
using Techan.ViewModels;

namespace Techan.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly TechanDbContext _context;

    public ProductController(TechanDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Product> products = await _context.Products.ToListAsync();

        ProductViewModel model = new()
        {
            Products = products,
        };

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        List<Brand> brands = await _context.Brands.ToListAsync();
        List<Category> categories = await _context.Categories.ToListAsync();

        ProductViewModel model = new ProductViewModel()
        {
            Brands = brands,
            Categories = categories,
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Update(Product product)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Delete()
    {
        return View();
    }
}
