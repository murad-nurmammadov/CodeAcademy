using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techan.Contexts;
using Techan.Models;
using Techan.ViewModels.BrandVMs;
using Techan.ViewModels.CategoryVMs;
using Techan.ViewModels.ProductVMs;

namespace Techan.Areas.Admin.Controllers;

public class ProductController(TechanDbContext _context) : AdminBaseController
{
    // Check everything below
    // TODO everything below
    public async Task<IActionResult> Index()
    {
        var vm = new ProductIndexVM()
        {
            Categories = await _context.Categories
                .Select(c => new CategoryGetVM { Id = c.Id, Name = c.Name })
                .ToListAsync(),

            Products = await _context.Products
                .Select(p => new ProductGetVM
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Cost = p.Cost,
                    DateAdded = p.DateAdded,
                    ImagePath = p.ImagePath,
                })
                .ToListAsync(),
        };

        return View(vm);
    }

    public async Task<IActionResult> Create()
    {
        var vm = new ProductCreateVM();
        await PopulateDropdownsAsync(vm);
        return View(vm);
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(ProductCreateVM model)
    {
        if (!ModelState.IsValid)
        {
            await PopulateDropdownsAsync(model);
            return View(model);
        }

        string? imagePath = null;

        if (model.Image != null)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
            string fullPath = Path.Combine("wwwroot", "uploads", fileName);

            using var fs = new FileStream(fullPath, FileMode.Create);
            await model.Image.CopyToAsync(fs);

            imagePath = "/uploads/" + fileName;
        }

        var product = new Product()
        {
            Title = model.Title,
            Description = model.Description,
            BrandId = model.BrandId,
            Cost = model.Cost,
            CategoryId = model.CategoryId,
            ImagePath = imagePath,
            DateAdded = DateTime.UtcNow,
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    // Helper Method
    private async Task PopulateDropdownsAsync(ProductCreateVM model)
    {
        model.Categories = await _context.Categories
            .Select(c => new CategoryGetVM { Id = c.Id, Name = c.Name })
            .ToListAsync();

        model.Brands = await _context.Brands
            .Select(b => new BrandGetVM { Id = b.Id, Name = b.Name })
            .ToListAsync();
    }
}
