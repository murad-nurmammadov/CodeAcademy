using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;
using Techan.Models;
using Techan.ViewModels.BrandVMs;

namespace Techan.Areas.Admin.Controllers;

[Area("Admin")]
public class BrandController(TechanDbContext _context) : Controller
{
    public async Task<IActionResult> Index()
    {
        List<Brand> brands = await _context.Brands.ToListAsync();

        List<BrandGetVM> brandVMs = brands.Select(b => new BrandGetVM
        {
            Name = b.Name,
            LogoPath = b.LogoPath,
        }).ToList();

        return View(brands);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(BrandCreateVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        string? logoPath = null;

        if (model.Logo != null)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(model.Logo.FileName);
            string fullPath = Path.Combine("wwwroot", "uploads", fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await model.Logo.CopyToAsync(stream);

            logoPath = "/uploads/" + fileName;
        }

        var brand = new Brand
        {
            Name = model.Name,
            LogoPath = logoPath,
        };

        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    // TODO:
    public async Task<IActionResult> Update(int id)
    {
        Brand? brand = await _context.Brands.FindAsync(id);

        if (brand == null)
            return NotFound();

        var vm = new BrandUpdateVM
        {
            Id = id,
            Name = brand.Name,
            ExistingLogoPath = brand.LogoPath,
        };

        return View(vm);
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Update(BrandUpdateVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        Brand? brand = await _context.Brands.FindAsync(model.Id);

        if (brand == null)
            return NotFound();

        brand.Name = model.Name;
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
