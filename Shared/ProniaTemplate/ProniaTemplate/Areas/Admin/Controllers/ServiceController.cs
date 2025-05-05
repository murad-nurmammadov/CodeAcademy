using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTemplate.Contexts;
using ProniaTemplate.Models;

namespace ProniaTemplate.Areas.Admin.Controllers;

[Area("Admin")]
public class ServiceController(ProniaDbContext _context) : Controller
{
    public async Task<IActionResult> Index()
    {
        List<Slider> sliders = await _context.Sliders.ToListAsync();
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

        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Update()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id)
    {
        return View();
    }

    public async Task<IActionResult> Delete()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest();

        var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);

        if (service is null)
            return NotFound();

        _context.Services.Remove(service);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
