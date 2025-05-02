using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;

namespace Techan.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest();

        using var context = new TechanDbContext();
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null)
            return NotFound();

        context.Products.Remove(product);
        await context.SaveChangesAsync();
         
        return RedirectToAction(nameof(Index));
    }
}
