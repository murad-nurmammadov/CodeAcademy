using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;
using Techan.Models;

namespace Techan.Areas.Admin.Controllers;

[Area("Admin")]
public class BrandController(TechanDbContext _context) : Controller
{
    public async Task<IActionResult> Index()
    {
        List<Brand> brands = await _context.Brands.ToListAsync();
        return View(brands);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(Brand brand)
    {
        if (!ModelState.IsValid)
            return View(brand);
        
        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Create));
    }

    public async Task<IActionResult> Update(int id)
    {
        Brand? brand = await _context.Brands.FindAsync(id);

        if (brand == null)
            return NotFound();

        return View(brand);
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Update(Brand brand)
    {
        if (!ModelState.IsValid)
            return View(brand);

        _context.Brands.Update(brand);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        Brand? brand = await _context.Brands.FindAsync(id);

        if (brand == null)
            return NotFound();

        _context.Remove(brand); 
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }
}
