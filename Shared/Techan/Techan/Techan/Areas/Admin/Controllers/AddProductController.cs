using Microsoft.AspNetCore.Mvc;
using Techan.Contexts;
using Techan.Models;

namespace Techan.Areas.Admin.Controllers;

[Area("Admin")]
public class AddProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (!ModelState.IsValid)
            return View(product);

        using var context = new TechanDbContext();
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
