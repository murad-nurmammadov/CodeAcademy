using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTemplate.Contexts;
using ProniaTemplate.Models;

namespace ProniaTemplate.Areas.Admin.Controllers;

public class ServiceController : Controller
{
    public async Task<IActionResult> Index()
    {
        using var context = new ProniaDbContext();
        List<Slider> sliders = await context.Sliders.ToListAsync();
        return View(sliders);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Service service)
    {
        if (!ModelState.IsValid)
            return View(service);

        using var context = new ProniaDbContext();
        await context.Services.AddAsync(service);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest();

        using var context = new ProniaDbContext();
        var service = await context.Services.FirstOrDefaultAsync(x => x.Id == id);

        if (service is null)
            return NotFound();

        context.Services.Remove(service);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

}
