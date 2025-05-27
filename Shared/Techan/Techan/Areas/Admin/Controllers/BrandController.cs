using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;
using Techan.Models;
using Techan.ViewModels.BrandVMs;
using Techan.ViewModels.CategoryVMs;

namespace Techan.Areas.Admin.Controllers;

public class BrandController(TechanDbContext _context) : AdminBaseController
{
    public async Task<IActionResult> Index()
    {
        List<Brand> brands = await _context.Brands.ToListAsync();
        List<BrandGetVM> brandVMs = brands.Select(b => new BrandGetVM
        {
            Id = b.Id,
            Name = b.Name,
            LogoPath = b.LogoPath,
        }).ToList();

        List<Category> categories = await _context.Categories.ToListAsync();
        List<CategoryGetVM> categoryVMs = categories.Select(c => new CategoryGetVM()
        {
            Id = c.Id,
            Name = c.Name,
        }).ToList(); 


        var vm = new BrandIndexVM()
        {
            Brands = brandVMs,
            Categories = categoryVMs,
        };

        return View(vm);
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

    public async Task<IActionResult> Update(int id)
    {
        Brand? brand = await _context.Brands.FindAsync(id);

        if (brand == null)
            return NotFound();

        var vm = new BrandUpdateVM
        {
            Id = id,
            Name = brand.Name,
            LogoPath = brand.LogoPath,
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

        // Add new logo (if any)
        if (model.NewLogo != null)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.NewLogo.FileName);
            string logoPath = "/uploads/" + fileName;
            string fullPath = Path.Combine("wwwroot", "uploads", fileName);

            using var fs = new FileStream(fullPath, FileMode.Create);
            await model.NewLogo.CopyToAsync(fs);

            // Delete old logo if exists
            if (!string.IsNullOrEmpty(brand.LogoPath))
            {
                string oldFullPath = Path.Combine("wwwroot", brand.LogoPath.TrimStart('/'));
                if (System.IO.File.Exists(oldFullPath))
                    System.IO.File.Delete(oldFullPath);
            }

            brand.LogoPath = logoPath;
        }

        brand.Name = model.Name;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        Brand? brand = await _context.Brands.FindAsync(id);

        if (brand == null)
            return NotFound();

        if (!string.IsNullOrWhiteSpace(brand.LogoPath))
        {
            // Convert from web path to physical path safely
            string safeRelativePath = brand.LogoPath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString());
            string fullPath = Path.Combine("wwwroot", safeRelativePath);

            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);
        }

        _context.Remove(brand);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
